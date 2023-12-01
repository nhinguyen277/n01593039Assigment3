function AddTeacher() {
    var firstname = document.getElementById("first_name").value;
    var lastname = document.getElementById("last_name").value;
    var number = document.getElementById("number").value;
    var salary = document.getElementById("salary").value;

    // alert("you clicked the button!" + firstname + " " + lastname);
    // send a request look like this:
    //http://localhost:58473/api/teacherdata/addteacher
    var url = "http://localhost:58473/api/teacherdata/addteacher";
    var rq = new XMLHttpRequest();
    // where is this request sent to?
    rq.onreadystatechange = function() {
        // ready state should be 4 and status should be 200
        if (rq.readyState == 4 && rq.status == 200) {
            // request is successful and the request is finished
            console.log(rq.responseText);

        }
    }
    rq.open("POST", url, true);
    rq.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    rq.send("TeacherFname=" + firstname + "&TeacherLname=" + lastname + "&TeacherNumber=" +
        number + "&TeacherSalary=" + salary);

}

function DeleteTeacher() {

    var id = document.getElementById("id").value;

    //alert("you clicked the button!" + id);
    // send a request look like this:
    //http://localhost:58473/api/teacherdata/deleteteacher/1
    var url = "http://localhost:58473/api/teacherdata/deleteteacher/";
    var rq = new XMLHttpRequest();
    // where is this request sent to?
    rq.onreadystatechange = function() {
        // ready state should be 4 and status should be 200
        if (rq.readyState == 4 && rq.status == 200) {
            // request is successful and the request is finished
            console.log(rq.responseText);

        }
    }
    rq.open("POST", url, true);
    rq.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    rq.send("id=" + id);

}