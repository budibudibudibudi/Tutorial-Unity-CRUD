<?php

$koneksi = mysqli_connect("localhost", "root", "", "tutorial_unity");

// Check connection
if (mysqli_connect_errno()) {
    echo "Koneksi database gagal : " . mysqli_connect_error();
}
$nama = $_POST["nama"];
$insertdatatoquery = "DELETE FROM data_player WHERE nama = '$nama'";
mysqli_query($koneksi,$insertdatatoquery) or die ("data cannot be deleted");
?>