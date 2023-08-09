<?php

$koneksi = mysqli_connect("localhost", "root", "", "tutorial_unity");

// Check connection
if (mysqli_connect_errno()) {
    echo "Koneksi database gagal : " . mysqli_connect_error();
}
$nama = $_POST['nama'];
$skor = $_POST['skor'];
$insertdatatoquery = "INSERT INTO data_player (nama, skor) VALUES ('$nama', '$skor')";
mysqli_query($koneksi,$insertdatatoquery) or die ("data cannot be added");
?>