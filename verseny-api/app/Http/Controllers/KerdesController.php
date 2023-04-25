<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class KerdesController extends Controller
{

    public function list(string $versenyId)
    {
        //TODO: Kérdések listázása az adott versenyhez
    }

    public function create(Request $request)
    {
        //TODO: Új kérdés létrehozása a request alapján
    }


    public function update(Request $request)
    {
        //TODO: kérdés szerkesztése
    }

    public function delete(Request $request)
    {
        //TODO: kérdés törlése
    }


}
