<?php
$servername = "h2923764.stratoserver.net";
$username = "gd03";
$password = "j9P4tTG9kd#mMo@T";
$dbname = "gamedev";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully";
$sql = "INSERT INTO Session_stats(P1_Atk, P2_Atk, AI_Atk, P1_Hit, P2_Hit, AI_Hit, P1_Jump, P2_Jump, AI_Jump, No_Round, No_Matches, P1_Wins, P2_Wins, Rnd_Time, Avg_RTime, Total_time, Longest_Rnd, Shortest_Rnd) VALUES ('" . $P1_Atk . "', '" . $P2_Atk . "', '" . $AI_Atk . "', '" . $P1_Jump . "', '" . $P2_Jump . "', '" . $AI_jump . "', '" . $No_Round . "', '" . $No_Matches . "', '" . $P1_Wins . "', '" . $P2_Wins . "', '" . $Rnd_Time . "', '" . $AVG_RTime . "', '" . $Total_time . "', '" . $Longest_Rnd . "', '" . $Shortest_Rnd . "')"

if ($conn->query($sql) === TRUE)
{
    echo "New record created sucessfully";
}
else
{
    echo "Error" . $sql . "<br>" . $conn->error;
}

$conn->close();
?>
