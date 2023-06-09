<?php

use App\Http\Controllers\DiakController;
use App\Http\Controllers\KerdesController;
use App\Http\Controllers\TanarController;
use App\Http\Controllers\VersenyDiakController;
use App\Http\Controllers\VersenyTanarController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "api" middleware group. Make something great!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

//Diákok
Route::post('diakok/signup', [DiakController::class, 'signup']);
Route::post('diakok/login', [DiakController::class, 'login']);

//Tanárok
Route::post('tanarok/signup', [TanarController::class,'signup']);
Route::post('tanarok/login', [TanarController::class,'login']);

//Versenyek - Tanároknak
Route::get('verseny/tanar/list', [VersenyTanarController::class,'list']);
Route::post('verseny/tanar/create', [VersenyTanarController::class,'create']);
Route::put('verseny/tanar/update/{verseny}', [VersenyTanarController::class,'update']);
Route::delete('verseny/tanar/delete/{verseny}', [VersenyTanarController::class,'delete']);

//Kérdések
Route::get('kerdes/list/{versenyId}', [KerdesController::class,'list']);
Route::post('kerdes/create', [KerdesController::class,'create']);
Route::put('kerdes/update/{kerdes}', [KerdesController::class,'update']);
Route::delete('kerdes/delete/{kerdes}', [KerdesController::class,'delete']);


//Versenyek - Diákoknak
Route::get('verseny/diak/list/{diakId}', [VersenyDiakController::class,'list']);
Route::get('verseny/diak/view/{diakId}/{verseny}', [VersenyDiakController::class,'view']);
Route::post('verseny/diak/submit', [VersenyDiakController::class,'submit']);
