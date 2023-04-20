<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Tanar extends Model
{
    use HasFactory;

    protected $table = 'tanarok';
    protected $fillable = [
        'username',
        'password',
        'email',
        'fullname',
        'subject',
        'class'
    ];
}
