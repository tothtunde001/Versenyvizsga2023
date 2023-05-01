<?php

namespace App\Http\Controllers;

use App\Models\KitoltottKerdes;
use App\Models\KitoltottVerseny;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class VersenyDiakController extends Controller
{

    public function list(string $diakId)
    {
        //TODO: Versenyek listázása. Meg kell jelölni a kitöltött versenyeket.
    }

    public function view(string $versenyId)
    {
        //TODO: Verseny megjelenítése
        // Ha még nincs kitöltve, akkor csak az alap adatok
        // Ha már ki van töltve, akkor a jelölt és a helyes válaszok is
    }

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
}
