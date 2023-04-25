<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class VersenyDiakController extends Controller
{

    public function list(string $diakId)
    {
        //TODO: Versenyek listázása. Meg kell jelölni a kitöltött versenyeket
    }

    public function view(string $versenyId)
    {
        //TODO: Verseny megjelenítése
        // Ha még nincs kitöltve, akkor csak az alap adatok
        // Ha már ki van töltve, akkor a jelölt és a helyes válaszok is
    }

    public function submit(Request $request)
    {
        //TODO: verseny beküldése
    }
}
