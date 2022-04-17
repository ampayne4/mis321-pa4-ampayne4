function findSongs(){
    // var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    const url = "https://localhost:5001/api/Songs"
    //var url = "jhdjjtqo9w5bzq2t.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
    let searchString = document.getElementById("searchSong").value;

    //url += searchString;

    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
        let count = 0
        html += `<div class = "row">`
		json.forEach((song) => {
            console.log(song.songTitle)
            if(song.deleted == "n"){
                html += `<div class="card col-md-4 bg-dark text-white">`;
                html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
                html += `<div class="card-img-overlay">`;
                html += `<h5 class="card-title">`+song.songTitle+`</h5>`;
                html += `</div>`;
                html += `</div>`;
            }
            

            if (count ==3){
                html += `</div><div class = "row">`;
            }
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("cards").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
}

function getSong(){
    const url = "https://localhost:5001/api/Songs"
    let searchString = document.getElementById("searchSong").value;
    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
        //console.log("TEST123")
        json.forEach((song) => {
            console.log(song.songTitle)
            if (searchString == song.songTitle)
            {
                console.log(song.songTitle)
                html += `<div class="card col-md-4 bg-dark text-white">`;
                html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
                html += `<div class="card-img-overlay">`;
                html += `<h5 class="card-title">`+song.songTitle+`</h5>`;
                html += `</div>`;
                html += `</div>`;
            }
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
}

function postSong(){
    const url = "https://localhost:5001/api/Songs"
    //const titleString = document.getElementById("title").value;
    const sendSong = {
        //songID: 10000,
        songTitle: document.getElementById("title").value,
        //songTimestamp: "2022-03-29T01:21:44",
        deleted: "n",
        favorited: "n"
    }

    fetch(url, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify(sendSong)
	}).then(function(json) {
        //let html = ``;
        //console.log(json)
        mySong = sendSong;
        console.log("Title:" + mySong.songTitle);
        console.log("Timestamp:" + mySong.songTimestamp);
        console.log("ID:" + mySong.songID);
		findSongs();
        //document.getElementById("addSongs").innerHTML = html;
	}).catch(function(error) {
		console.log(error)
    })
}

function putSong(id){
    const url = "https://localhost:5001/api/Songs"
    //const titleString = document.getElementById("title").value;
    const sendSong = {
        songID: document.getElementById("favoriteSong").value,
        //songTimestamp: "2022-03-29T01:21:44",
        deleted: "n",
        favorited: "y",
    }

    fetch(url, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify(sendSong)
	}).then(function(json) {
        //let html = ``;
        //console.log(json)
        mySong = sendSong;
        console.log("Title:" + mySong.songTitle);
        console.log("Timestamp:" + mySong.songTimestamp);
        console.log("ID:" + mySong.songID);
		findSongs();
        //document.getElementById("addSongs").innerHTML = html;
	}).catch(function(error) {
		console.log(error)
    })
}


// function putSong(){
//     const url = "https://localhost:5001/api/Songs"
//     //const titleString = document.getElementById("title").value;
//     const putID = document.getElementById("favoriteSongTitle")
//     fetch(url, {
//         method: "PUT",
//         headers: {
//             "Accept": 'application/json',
//             "Content-Type": 'application/json',
//         },
//         body: JSON.stringify(putID)
// 	}).then(function(json) {
//         //id = sendSong;
// 		findSongs();
// 	}).catch(function(error) {
// 		console.log(error)
//     })
// }

// function deleteSongByID(){
//     const url = "https://localhost:5001/api/Songs"
//     //const titleString = document.getElementById("title").value;
//     const deleteID = document.getElementById("deleteSong").value;
//     console.log("Delete ID = " + deleteID);
//     // const sendSong = {
//     //     songID: document.getElementById("deleteSong").value,
//     //     //songTimestamp: "2022-03-29T01:21:44",
//     // }
//     fetch(url, {
//         method: "DELETE",
//         headers: {
//             "Accept": 'application/json',
//             "Content-Type": 'application/json'
//         },
//         body: JSON.stringify(deleteID)
// 	}).then(function(json) {
//         id = deleteID;
//         //let html = ``;
//         //console.log(json)
//         // mySong = sendSong;
//         // console.log("Title:" + mySong.songTitle);
//         // console.log("Timestamp:" + mySong.songTimestamp);
//         // console.log("ID:" + mySong.songID);
// 		findSongs();
//         //document.getElementById("addSongs").innerHTML = html;
// 	}).catch(function(error) {
// 		console.log(error)
//     })
// }




// function findSongs(){
//     var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
//     let searchString = document.getElementById("searchSong").value;

//     url += searchString;

//     console.log(searchString)

//     fetch(url).then(function(response) {
// 		//console.log(response);
// 		return response.json();
// 	}).then(function(json) {
//         //console.log(json)
//         let html = ``;
// 		json.forEach((song) => {
//             console.log(song.title)
//             html += `<div class="card col-md-4 bg-dark text-white">`;
// 			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
// 			html += `<div class="card-img-overlay">`;
// 			html += `<h5 class="card-title">`+song.title+`</h5>`;
//             html += `</div>`;
//             html += `</div>`;
// 		});
		
//         if(html === ``){
//             html = "No Songs found :("
//         }
// 		document.getElementById("searchSongs").innerHTML = html;

// 	}).catch(function(error) {
// 		console.log(error);
// 	})
// }