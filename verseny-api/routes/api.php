<?php

use App\Http\Controllers\DiakController;
use App\Http\Controllers\TanarController;
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
