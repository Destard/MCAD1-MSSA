document.addEventListener("DOMContentLoaded", function () {
    let classDays = [
        {
            dayNumber: 1,
            assignments: "10.1 - Creating an about me page"
        },
        {
            dayNumber: 2,
            assignments: "10.2 - Designing basic javascript functionality, 10.2.1 - Create an HTML5 Form"
        },
    ];
    function displayAssignments(dayNumber) {
        sectionSelectedDayNumber.innerHTML = "You selected day " + dayNumber;
        sectionSelectedDayAssignments.innerHTML = "Assignments for that day are " + classDays[dayNumber - 1].assignments;
    }
    function appendAssignments(dayNumber) {
        //Create two section elements with their inner HTML set to the day number and assignments.
        var dayNumberSection = document.createElement("section");
        var dayAssignmentsSection = document.createElement("section");
        dayNumberSection.innerHTML = "You selected day " + dayNumber;
        dayAssignmentsSection.innerHTML = "Assignments for that day are " + classDays[dayNumber - 1].assignments;
        //After creating the HTML elements, I have to append them to a parent element.
        articleDayInformation.appendChild(dayNumberSection);
        articleDayInformation.appendChild(dayAssignmentsSection);
    }
    let btnClick = document.getElementById("btnClick");
    let txtClassDay = document.getElementById("txtClassDay");
    let sectionSelectedDayNumber = document.getElementById("sectionSelectedDayNumber");
    let sectionSelectedDayAssignments = document.getElementById("sectionSelectedDayAssignments");
    let articleDayInformation = document.getElementById("articleDayInformation");
    //Add code that will execute when my button is clicked.
    btnClick.addEventListener("click", function () {
        let selectedDay = txtClassDay.value; //have that code read the value of my textbox.
        //displayAssignments(selectedDay);
        appendAssignments(selectedDay);
    });
})