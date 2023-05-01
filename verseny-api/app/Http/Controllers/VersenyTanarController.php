<?php

namespace App\Http\Controllers;

use App\Models\Verseny;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class VersenyTanarController extends Controller
{

    /**
     * GET http://127.0.0.1:8000/api/verseny/tanar/list
     * - az összes verseny kilistázása
     */
    public function list()
    {
        $versenyek = Verseny::all();
        return [
            "status" => 'OK',
            "data" => $versenyek
        ];
    }

    /**
     * POST http://127.0.0.1:8000/api/verseny/tanar/create
     * - új verseny létrehozása
     * - a nevet és a leírást kell megadni
     */
    public function create(Request $request)
    {
        // Input validálása

        $validator = Validator::make($request->all(), [
            'competition_name' => 'required',
            'description' => 'required'
        ]);

        if ($validator->fails()) {
            return [
                "status" => "ERROR",
                "message" => "Hiányzó adatok a verseny létrehozásához."
            ];
        }

        $verseny = Verseny::create($request->all());
        return [
            "status" => 'OK',
            "data" => $verseny,
            "message" =>'A verseny sikeresen létrehozva.'
        ];
    }

    /**
     * PUT http://127.0.0.1:8000/api/verseny/tanar/update/{verseny}
     * - verseny módosítása
     */
    public function update(Request $request, Verseny $verseny)
    {
        // Input validálása

        $validator = Validator::make($request->all(), [
            'competition_name' => 'required',
            'description' => 'required'
        ]);

        if ($validator->fails()) {
            return [
                "status" => "ERROR",
                "message" => "Hiányzó adatok a verseny módosításához."
            ];
        }

        $verseny->update($request->all());

        return [
            "status" => 'OK',
            "data" => $verseny,
            "message" => "Sikeres verseny módosítás."
        ];

    }

    /**
     * DELETE http://127.0.0.1:8000/api/verseny/tanar/delete/{verseny}
     * - verseny törlése
     */
    public function delete(Verseny $verseny)
    {
        $verseny->delete();
        return [
            "status" => "OK",
            "data" => $verseny,
            "message" => "A verseny sikeresen törölve."
        ];
    }
}
