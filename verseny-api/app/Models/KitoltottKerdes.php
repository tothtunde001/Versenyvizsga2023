<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class KitoltottKerdes extends Model
{
    use HasFactory;

    protected $table = 'kitoltottkerdesek';
    protected $fillable = [
        'submittedCompetitionId',
        'questionId',
        'studentAnswer'
    ];
}
