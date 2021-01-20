# This file will test reserved URL characters against test server
# 

$v3port="9001"
$v4port="9002"
function MakeRequest {
    param (
        $Parameter,
        $Encodingcount
    )
    Write-Host "==================================================================================================="
    Write-Host "Encoding count- ${Encodingcount}, input: ${Parameter}" -ForegroundColor Green 
    while ($Encodingcount -gt 0) {
        $Parameter=[System.Uri]::EscapeDataString($Parameter)
        $Encodingcount=$Encodingcount-1
    }
    $testurl1="http://localhost:${v3port}/api/values/${Parameter}/${Parameter}?query1=${Parameter}&query2=${Parameter}&query3=${Parameter}"
    Write-Host "Processing : ${testurl1}" -ForegroundColor Green 
    $resp1=Invoke-WebRequest -Uri $testurl1 -Headers @{"Accept"="application/json"} 
    Write-Host "Status:" $resp1.StatusCode $resp1.StatusDescription
    $resp1.Content
    Write-Host

    $testurl2="http://localhost:${v4port}/api/values/${Parameter}/${Parameter}?query1=${Parameter}&query2=${Parameter}&query3=${Parameter}"
    Write-Host "Processing : ${testurl2}" -ForegroundColor Green 
    $resp2=Invoke-WebRequest -Uri $testurl2 -Headers @{"Accept"="application/json"} 
    Write-Host "Status:" $resp2.StatusCode $resp2.StatusDescription
    $resp2.Content
    Write-Host
}

$withoutplusslash=":?#[]@`"!$&'()*,;="; #  :?#[]@"!$&'()*,;=  All Url reserved characters except '+','/'
MakeRequest -Parameter $withoutplusslash  -Encodingcount 0
MakeRequest -Parameter $withoutplusslash  -Encodingcount 1
MakeRequest -Parameter $withoutplusslash  -Encodingcount 2
MakeRequest -Parameter $withoutplusslash  -Encodingcount 3
$withplus=":?#[]@`"!$&'()*,;=+";   # :?#[]@"!$&'()*,;=+     All Url reserved characters except /'
MakeRequest -Parameter $withplus  -Encodingcount 0
MakeRequest -Parameter $withplus  -Encodingcount 1
MakeRequest -Parameter $withplus  -Encodingcount 2
MakeRequest -Parameter $withplus  -Encodingcount 3
$withplusslash=":?#[]@`"!$&'()*,;=+/";  # :?#[]@"!$&'()*,;=+/  All Url reserved characters
MakeRequest -Parameter $withplusslash  -Encodingcount 0
MakeRequest -Parameter $withplusslash  -Encodingcount 1
MakeRequest -Parameter $withplusslash  -Encodingcount 2
MakeRequest -Parameter $withplusslash  -Encodingcount 3

