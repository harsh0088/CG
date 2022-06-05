function createfile() {
    try
    {
     fetch('https://localhost:44392/api/Document/'+sessionStorage.getItem("folderid"), {
       body: JSON.stringify({
        // "folderName": form.value,
        // "createdBy": id,
        // "isDeleted": 0,
        "documentName": form.value,
          "createdAt": curr.toISOString(),
          "isDeleted": 0,
          "contentType": "c#",
          "size": 120,
          "createdBy": id,
          "folderId": sessionStorage.getItem("folderId"),
          
      }),
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
        fetch('https://localhost:44392/api/Document/'+sessionStorage.getItem("folderId"), {
          method: 'GET'
        })
        .then(response => response.json())
        .then((folders) => {
          console.log(folders);
          folders.forEach(folder => {
        
          var create = document.getElementById("create");
          var art = document.createElement("article");
          console.log(folder);
          const fold = folder.documentName;
          console.log(fold);
          // fold.style.backgroundColor = "red";
          // console.log(fold);
          art.innerHTML = `<i class=" filei fa-2x fa-solid fa-file"></i>
          <button style="font-size:  20px;text-decoration: none;position: relative;left: 400px;bottom: 2px;cursor: pointer;">${fold}</button>
          
          </i>`;
          create.appendChild(art);
          });
        })
        
        }
        catch(err)
        {
          console.log(err);
        }
      }