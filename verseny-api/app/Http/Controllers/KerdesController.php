<?php

namespace App\Http\Controllers;

use App\Models\Kerdes;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class KerdesController extends Controller
{

    /**
     * GET http://127.0.0.1:8000/api/kerdes/list/{versenyId}
     * - Kérdések listázása egy adott versenyhez
     * - A verseny azonosítót paraméterben kell megadni
     */
    public function list(string $versenyId)
    {
        //Kérdések listázása az adott versenyhez
        $versenyKerdesei = Kerdes::query() -> where('competitionId',  $versenyId)->get();

        return [
            "status" => 'OK',
            "data" => $versenyKerdesei
        ];
    }

    /**
     * POST http://127.0.0.1:8000/api/kerdes/create
     * - új kérdés létrehozása
     * - meg kell adni a verseny azonosítót is
     * - a válaszlehetőségeket és a helyes választ is meg kell adni
     */
    public function create(Request $request)
    {
        // Input validálása

        $validator = Validator::make($request->all(), [
            'competitionId' => 'required',
            'question' => 'required',
            'answer1' => 'required',
            'answer2' => 'required',
            'answer3' => 'required',
            'answer4' => 'required',
            'correctAnswer' => 'required'
        ]);

        if ($validator->fails()) {
            return [
                "status" => "ERROR",
                "message" => "Hiányzó adatok a kérdés létrehozásához."
            ];
        }

        $kerdes = Kerdes::create($request->all());
        return [
            "status" => 'OK',
            "data" => $kerdes,
            "message" =>'A kérdés sikeresen létrehozva.'
        ];
    }


    /**
     * PUT http://127.0.0.1:8000/api/kerdes/update/{kerdes}
     * - Kérdés módosítása
     */
    public function update(Request $request, Kerdes $kerdes)
    {
        // Input validálása

        $validator = Validator::make($request->all(), [
            'competitionId' => 'required',
            'question' => 'required',
            'answer1' => 'required',
            'answer2' => 'required',
            'answer3' => 'required',
            'answer4' => 'required',
            'correctAnswer' => 'required'
        ]);

        if ($validator->fails()) {
            return [
                "status" => "ERROR",
                "message" => "Hiányzó adatok a kérdés módosításához."
            ];
        }

        $kerdes->update($request->all());

        return [
            "status" => 'OK',
            "data" => $kerdes,
            "message" => "Sikeres kérdés módosítás."
        ];
    }

    /**
     * DELETE http://127.0.0.1:8000/api/verseny/tanar/delete/{kerdes}
     * - Kérdés törlése
     */
    public function delete(Kerdes $kerdes)
    {
        $kerdes->delete();
        return [
            "status" => "OK",
            "data" => $kerdes,
            "message" => "A kérdés sikeresen törölve."
        ];
    }
}
