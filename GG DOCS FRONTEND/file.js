var form=document.getElementById("input1");
function createfile() {
    try
    {
     fetch('http://localhost:64658/api/Document', {
       body: JSON.stringify({
       
        "documentName": form.value,
        "documentContentType": "text",
        "documentSize": 100,
        "documentCreatedBy": sessionStorage.getItem("userid"),
        "documentCreatedAt": "2022-06-01T18:37:00",
        "documentIsDeleted": false,
          "folderId": sessionStorage.getItem("folderid"),
          
      }),
       method: 'POST',
       headers: {
        'Content-Type': 'application/json'
      },
     }).then((folderCreateResponse) => {
        console.log(folderCreateResponse);
         listFile();
     });
    }
    catch(err)
    {
      console.log(err);
    }
    } 
      function listFile() {
        try
        {
          var create = document.getElementById("create");
          create.innerHTML = '';
        fetch('http://localhost:64658/api/Document/'+sessionStorage.getItem("folderid"), {
          method: 'GET'
        })
        .then(response => response.json())
        .then((folders) => {
          console.log(folders);
          folders.forEach(folder => {
        
          var create = document.getElementById("create");
          var art = document.createElement("article");
          console.log(folder);
          const fname = folder.documentName;
          art.innerHTML = `<button id="filebtn" style="text-decoration: none;font-weight:bold;border: 0px; background: #e8f3ee;margin-top:30px;margin-left:100px;"> ${fname} </button>`;;
          create.appendChild(art);
          });
        })
        
        }
        catch(err)
        {
          console.log(err);
        }
      }
      
  function onLoad() {
    listFile();
document.getElementById("adminName").innerHTML="Hi, "+sessionStorage.getItem("username") + "!";
  }
  
 onLoad();
 function logout(){
  sessionStorage.clear();
  window.location.href="index.html";
}