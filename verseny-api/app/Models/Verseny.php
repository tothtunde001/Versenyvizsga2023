<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Verseny extends Model
{
    use HasFactory;

    protected $table = 'versenyek';
    protected $fillable = [
        'competition_name',
        'description'
    ];
}
