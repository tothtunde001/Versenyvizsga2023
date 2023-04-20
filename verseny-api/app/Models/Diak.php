<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Diak extends Model
{
    use HasFactory;

    protected $table = 'diakok';
    protected $fillable = [
        'username',
        'password',
        'fullname',
        'email',
        'school',
        'class'
    ];



}
