<?php

namespace App\Http\Controllers;

use App\Models\Verseny;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class VersenyTanarController extends Controller
{

    public function list()
    {
        $versenyek = Verseny::all();
        return [
            "status" => 'OK',
            "data" => $versenyek
        ];

    }

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
