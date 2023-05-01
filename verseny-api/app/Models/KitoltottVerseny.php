<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class KitoltottVerseny extends Model
{
    use HasFactory;

    protected $table = 'kitoltottversenyek';
    protected $fillable = [
        'studentId',
        'competitionId'
    ];
}
