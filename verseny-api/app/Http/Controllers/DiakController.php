<?php

namespace App\Http\Controllers;

use App\Models\Diak;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class DiakController extends Controller
{
    /**
     * POST http://127.0.0.1:8000/api/diakok/signup
     * - új diák regisztrációja
     * - ellenőrzi a hiányzó adatokatokat
     * - ellenőrzi hogy már létezik-e a username
     */
    public function signup(Request $request)
    {
        // Input validálása

        $validator = Validator::make($request->all(), [
            'username' => 'required',
            'password' => 'required',
            'fullname' => 'required',
            'email' => 'required',
            'school' => 'required',
            'class' => 'required'
        ]);

        if ($validator->fails()) {
            return [
                "status"=> "ERROR",
                "message"=> "Hiányzó adatok a regisztrációban."
            ];
        }

        // Létező username keresése

        $existingDiak = Diak::query() -> where('username',  $request->username)->first();

        if ($existingDiak != null) {
            return [
                "status"=> "ERROR",
                "message"=> "Ez a felhasználónév már foglalt."
            ];
        }

        //Diák beszúrása

        Diak::create($request->all());

        return [
            "status"=> "OK",
            "message"=> "Sikeres regisztráció"
        ];
    }

    /**
     * POST http://127.0.0.1:8000/api/diakok/login
     * - diák bejelentkeztetése
     * - ellenőrzi az adatbázisban a felhasználónév-jelszó párost
     * - találat esetén visszaadja a diák azonosítóját
     */
    public function login(Request $request)
    {
        // Kivesszük a request-ből a szükséges elemeket
        $username = $request->username;
        $password = $request->password;

        // Megpróbáljuk megtalálni a diákot a username-password alapján
        $diak = Diak::query() -> where([
            ['username', '=',  $username],
            ['password', '=',  $password]])->first();

        // Ha nem találjuk, hibás bejelentkezés
        if ($diak == null) {
            return [
                "status"=> "ERROR",
                "message"=> "Hibás felhasználónév vagy jelszó."
            ];
        }

        // Egyébként sikeres bejelentkezés
        return [
            "status" => "OK",
            "message" => "Sikeres bejelentkezés",
            "id" => $diak->id,
        ];
    }
}
