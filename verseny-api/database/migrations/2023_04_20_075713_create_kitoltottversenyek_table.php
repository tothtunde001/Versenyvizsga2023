<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('kitoltottversenyek', function (Blueprint $table) {
            $table->id();
            $table->string('diakid');
            $table->integer('versenyid');
            $table->integer('osszpontszam');
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('kitoltottversenyek');
    }
};
