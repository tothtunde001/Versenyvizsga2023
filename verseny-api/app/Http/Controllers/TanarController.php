<?php

namespace App\Http\Controllers;

use App\Models\Tanar;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class TanarController extends Controller
{
    /**
     * POST http://127.0.0.1:8000/api/tanarok/signup
     * - új tanár regisztrációja
     * - ellenőrzi a hiányzó adatokatokat
     * - ellenőrzi hogy már létezik-e a username
     */
    public function signup(Request $request)
    {
        // Input validálása

        $validator = Validator::make($request->all(), [
            'username' => 'required',
            'password' => 'required',
            'email' => 'required',
            'fullname' => 'required',
            'subject' => 'required',
            'class' => 'required'
        ]);
        if ($validator->fails()) {
            return [
                "status" => "ERROR",
                "message" => "Hiányzó adatok a regisztrációban."
            ];
        }

        // Létező username keresése

        $existingTanar = Tanar::query()->where('username', $request->username)->first();

        if ($existingTanar != null) {
            return [
                "status" => "ERROR",
                "message" => "Ez a felhasználónév már foglalt."
            ];
        }
        //Tanár beszúrása

        Tanar::create($request->all());

        return [
            "status" => "OK",
            "message" => "Sikeres regisztráció"
        ];

    }

    /**
     * POST http://127.0.0.1:8000/api/tanarok/login
     * - új tanár regisztrációja
     * - ellenőrzi a hiányzó adatokatokat
     * - ellenőrzi hogy már létezik-e a username
     */
    public function login(Request $request)
    {
        // Kivesszük a request-ből a szükséges elemeket
        $username = $request->username;
        $password = $request->password;

        // Megpróbáljuk megtalálni a tanárt a username-password alapján
        $tanar = Tanar::query()->where([
            ['username', '=', $username],
            ['password', '=', $password]])->first();

        // Ha nem találjuk, hibás bejelentkezés
        if ($tanar == null) {
            return [
                "status" => "ERROR",
                "message" => "Hibás felhasználónév vagy jelszó."
            ];
        }
        // Egyébként sikeres bejelentkezés
        return [
            "status" => "OK",
            "message" => "Sikeres bejelentkezés",
            "id" => $tanar->id,
        ];
    }
}
