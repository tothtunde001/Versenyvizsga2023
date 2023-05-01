<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Kerdes extends Model
{
    use HasFactory;

    protected $table = 'kerdesek';
    protected $fillable = [
        'competitionId',
        'question',
        'answer1',
        'answer2',
        'answer3',
        'answer4',
        'correctAnswer'
    ];
}
