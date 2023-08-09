<?php

$koneksi = mysqli_connect("localhost", "root", "", "tutorial_unity");

// Check connection
if (mysqli_connect_errno()) {
    echo "Koneksi database gagal : " . mysqli_connect_error();
}


$sql = "select * from data_player";
$result = $koneksi->query($sql);

while ($data = mysqli_fetch_array($result)) {
    $item[] = array(
        'nama' =>$data["nama"],
        'skor' => $data["skor"]
    );
}


header('Content-Type: application/json');
echo json_encode($item);