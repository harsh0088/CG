// function validate_password() {
//     var password = document.getElementById('password').value;

//     var confirmPassword = document.getElementById('confirmPassword').value;

//     if (password != confirmPassword) {

//         document.getElementById('wrongPassowrd').style.color = 'red';

//         document.getElementById('wrongPassowrd').innerHTML

//           = '☒ Use same password';

//         document.getElementById('create').disabled = true;

//         document.getElementById('create').style.opacity = (0.4);

//     } else {

//         document.getElementById('wrongPassowrd').style.color = 'green';

//         document.getElementById('wrongPassowrd').innerHTML =

//             '🗹 Password Matched';

//         document.getElementById('create').disabled = false;

//         document.getElementById('create').style.opacity = (1);

//     }

// }



// function wrong_pass_alert() {

//     if (document.getElementById('password').value != "" &&

//         document.getElementById('confirmPassword').value != "") {

//         alert("Your response is submitted");

//     } else {

//         alert("Please fill all the fields");

//     }
// }



function sendData(){

      let user=document.getElementById("userName").value;
    
      let password=document.getElementById("password").value;
    
      var curr=new Date();
    
      var DateTime=curr.getFullYear()+"-"+curr.getMonth()+"-"+curr.getDay()+" "+ curr.getHours() + ":" 
    
      + curr.getMinutes() + ":" + curr.getSeconds();
    
      console.log(DateTime);
    
      var request={
    
        method:'POST',
    
        redirect:'follow',
    
        body: JSON.stringify({
    
          "Username": user,
    
          "UserPassword":password,
    
          // "password":CryptoJS.MD5(password).toString(),
    
          "CreatedAt": DateTime
    
        }),
    
        
    
        // Adding headers to the request
    
        headers: {
    
          "Content-type": "application/json; charset=UTF-8"
    
        }
      };
    
      fetch("http://localhost:64658/api/User", request)
    
      .then(response => response.text())
    
      .then(result => console.log(result))
    
      .catch(error => console.log('error', error));}