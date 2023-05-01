<?php

namespace App\Http\Controllers;

use App\Models\Kerdes;
use App\Models\KitoltottKerdes;
use App\Models\KitoltottVerseny;
use App\Models\Verseny;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class VersenyDiakController extends Controller
{

    /**
     * GET http://127.0.0.1:8000/api/verseny/diak/list/{diakId}
     * - versenyek listázása
     * - minden versenynél meg van jelölve, hogy azt már beküldte-e a diák
     */
    public function list(string $diakId)
    {
        //Kitöltött versenyId-k összegyűjtése
        $kitoltottVersenyekId = $this->collectSubmittedCompetitionIds($diakId);

        // Összes verseny listázása
        $versenyek = Verseny::all();

        // Minden versenynél beállítjuk, hogy már beküldte-e a diák
        foreach ($versenyek as $verseny) {
            $submitted = in_array($verseny->id, $kitoltottVersenyekId);
            $verseny->submitted = $submitted;
        }

        return [
            "status" => 'OK',
            "data" => $versenyek,
        ];
    }

    /**
     * GET http://127.0.0.1:8000/api/verseny/diak/view/{diakId}/{verseny}
     * - kérdések kilistázása az adott versenyhez
     * - ha a diák még nem küldött megoldást, akkor a helyes válaszok nem látszanak
     * - ha már küldött megoldást, akkor a helyes válaszokat és a beküldött válaszokat is tartalmazza a válasz
     */
    public function view(string $diakId, Verseny $verseny)
    {
        //Kitöltött versenyId-k összegyűjtése
        $kitoltottVersenyekId = $this->collectSubmittedCompetitionIds($diakId);
        $submitted = in_array($verseny->id, $kitoltottVersenyekId);

        //Kérdések listázása az adott versenyhez
        $versenyKerdesei = Kerdes::query()
            -> where('competitionId',  $verseny->id)
            -> get();

        // Ha már ki van töltve, akkor a jelölt és a helyes válaszok is
        if($submitted) {
            //Saját válasz hozzáadása
            $kitoltottVerseny = KitoltottVerseny::query()
                -> where('studentId',  $diakId)
                -> where('competitionId',  $verseny->id)
                -> first();
            foreach ($versenyKerdesei as $kerdes) {
                $sajatValasz = KitoltottKerdes::query()
                    -> where('submittedCompetitionId', $kitoltottVerseny->id)
                    -> where('questionId', $kerdes->id)
                    -> first();
                $kerdes->studentAnswer = $sajatValasz->studentAnswer;
            }
        }
        // Ha még nincs kitöltve, akkor csak az alap adatok
        else {
            //Helyes válasz elrejtése
            foreach ($versenyKerdesei as $kerdes) {
                unset($kerdes->correctAnswer);
            }
        }

        return [
            "status" => "OK",
            "verseny" => $verseny,
            "submitted" => $submitted,
            "kerdesek" => $versenyKerdesei
        ];
    }

    /**
     * POST http://127.0.0.1:8000/api/verseny/diak/submit
     * - megoldás beküldése egy versenyre
     * - meg kell adni a diák és a verseny azonosítóját
     * - valamint az összes versenyhez kapcsolódó kérdésre a választ
     */
    public function submit(Request $request)
    {
        // Input validálása

        $validator = Validator::make($request->all(), [
            'studentId' => 'required',
            'competitionId' => 'required'
        ]);

        if ($validator->fails()) {
            return [
                "status" => "ERROR",
                "message" => "Hiányzó adatok a verseny beküldéséhez."
            ];
        }

        // Ellenőrizzük, hogy korábban már beküldte-e
        $kitoltottVerseny = KitoltottVerseny::query()
            -> where('studentId',  $request->studentId)
            -> where('competitionId',  $request->competitionId)
            ->first();

        if ($kitoltottVerseny != null) {
            return [
                "status" => "ERROR",
                "message" => "Erre a versenyre már beadtad a megoldásod."
            ];
        }

        // Verseny beküldése a db-be
        $kitoltottVerseny = KitoltottVerseny::create(array(
            'studentId' => $request->studentId,
            'competitionId' => $request->competitionId
        ));
        $submittedCompetitionId = $kitoltottVerseny->id;

        // Beküldött válaszok beküldése a db-be
        $studentAnswers = $request->studentAnswers;

        $kitoltottKerdesek = [];
        foreach ($studentAnswers as $questionId => $studentAnswer) {
            $kitoltottKerdes = KitoltottKerdes::create(array(
                'submittedCompetitionId' => $submittedCompetitionId,
                'questionId' => $questionId,
                'studentAnswer' => $studentAnswer
            ));
            array_push($kitoltottKerdesek, $kitoltottKerdes);
        }

        return [
            "status" => "OK",
            "message" => "A megoldásod a versenyre sikeresen beküldve.",
            "versenyData" => $kitoltottVerseny,
            "kerdesData" => $kitoltottKerdesek
        ];
    }

    //Kitöltött versenyId-k összegyűjtése
    private function collectSubmittedCompetitionIds(string $diakId): array
    {
        $kitoltottVersenyek = KitoltottVerseny::query()
            -> where('studentId',  $diakId)
            -> get();

        $kitoltottVersenyekId = [];

        foreach ($kitoltottVersenyek as $item) {
            array_push($kitoltottVersenyekId, $item->competitionId);
        }

        return $kitoltottVersenyekId;
    }
}
