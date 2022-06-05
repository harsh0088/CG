// const html = document.documentElement;
// const body = document.body;
// import { constants } from './constants.js'
const constants = {
    apiBasePath: 'http://localhost:64658/api/'
  }
 
  const form = document.getElementById("input1");
  console.log(form);
  
  function createFolders() {
    try
    {
     fetch(`${constants.apiBasePath}Folder`, {
       body: JSON.stringify(
      {
        "folderName": form.value,
        "folderCreatedBy" : sessionStorage.getItem("userid"),
    //     "folderCreatedAt":"null",
    // "folderIsDeleted": 0
    }
      
      ),
       method: 'POST',
       headers: {
        'Content-Type': 'application/json'
      },
     }).then((folderCreateResponse) => {
        console.log(folderCreateResponse);
         listFolders();
     });
    }
    catch(err)
    {
      console.log(err);
    }
  }
  
  function listFolders() {
    try
    {
      var create = document.getElementById("create");
      create.innerHTML = '';
    fetch(`${constants.apiBasePath}Folder/`+sessionStorage.getItem("userid"), {
      method: 'GET'
    })
    .then(response => response.json())
    .then((folders) => {
      console.log(folders);
    folders.forEach(folder => {
   
      var create = document.getElementById("create");
      var art = document.createElement("article");
      const fname = folder.folderName;
      const folderid=folder.folderId;

      // fold.style.backgroundColor = "red";
      console.log(fname);
      console.log(folderid);
      art.innerHTML =
      `<button id="filebtn" onclick ="createfiles()"> ${fname} </button>`;
      
       
    
      create.appendChild(art);
      });
    
    })}
    catch(err)
    {
      console.log(err);
    }
  } 
  function createfiles(){
debugger;
// sessionStorage.setItem("folderid",folderid);
window.location.href="file.html";
  }
  
  function onLoad() {
    listFolders();
document.getElementById("adminName").innerHTML="Hi, "+sessionStorage.getItem("username") + "!";
  }
  
 onLoad();


//  file path 


const next = document.getElementById('hello');
console.log(next);

  


// console.log(next);



