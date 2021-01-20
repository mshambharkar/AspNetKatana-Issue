function execute(data){
fetch(`http://localhost:9001/api/values/${data}/${data}?query1=${data}&query2=${data}&query3=${data}`, {
  "headers": {
    "accept": "application/json",
    "accept-language": "en-US,en;q=0.9",
    "sec-ch-ua": "\"Google Chrome\";v=\"87\", \" Not;A Brand\";v=\"99\", \"Chromium\";v=\"87\"",
    "sec-ch-ua-mobile": "?0",
    "sec-fetch-dest": "empty",
    "sec-fetch-mode": "cors",
    "sec-fetch-site": "same-origin"
  },
  "referrerPolicy": "strict-origin-when-cross-origin",
  "body": null,
  "method": "GET",
  "mode": "cors",
  "credentials": "include"
}).then (response=> {
	if(!response.ok) {
		console.warn(response);
	}
	return response.json();
}).then(data=>{console.log(data);});
}

function encodedata(data,count){
	let encodeddata=data;
	for(let i=0;i < count;i++){
		encodeddata=encodeURIComponent(encodeddata);
	}
	return encodeddata;
}

let withoutplusslash=`:?#[]@"!$&'()*,;=`;
execute(encodedata(withoutplusslash,0));
execute(encodedata(withoutplusslash,1));
execute(encodedata(withoutplusslash,2));
execute(encodedata(withoutplusslash,3));
let withplus=`:?#[]@"!$&'()*,;=+`;
execute(encodedata(withplus,0));
execute(encodedata(withplus,1));
execute(encodedata(withplus,2));
execute(encodedata(withplus,3));
let withplusslash=`:?#[]@"!$&'()*,;=+/`;
execute(encodedata(withplusslash,0));
execute(encodedata(withplusslash,1));
execute(encodedata(withplusslash,2));
execute(encodedata(withplusslash,3));

