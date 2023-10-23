function attachEvents() {
  let students = [];
  const body = document.getElementsByTagName('tbody')[0];

  const URL = 'http://localhost:3030/jsonstore/collections/students';
  fetch(URL)
  .then((res)=>{
    res.json()
    .then((json)=>{
      for (const entry of Object.values(json)) {
        create(entry);
      }
    })
  });
  function create(entry){
    const row = document.createElement('tr');

    const firstName = entry.firstName;
    const col1 = document.createElement('td');
    col1.textContent=firstName;

    const lastName = entry.lastName;
    const col2 = document.createElement('td');
    col2.textContent=lastName;

    const facultyNumber = entry.facultyNumber;
    const col3 = document.createElement('td');
    col3.textContent=facultyNumber;

    const grade = Number(entry.grade);
    const col4 = document.createElement('td');
    col4.textContent=grade;

    const student = {
      firstName:firstName,
      lastName:lastName,
      facultyNumber:facultyNumber,
      grade:grade
    }
    students.push(student);

    row.appendChild(col1);
    row.appendChild(col2);
    row.appendChild(col3);
    row.appendChild(col4);
    body.appendChild(row);
  }
  const submitBtn = document.getElementById('submit');
  submitBtn.addEventListener('click',function(){
    const inputs = document.getElementsByClassName('inputs')[0];
    const firstName = inputs.getElementsByTagName('input')[0].value;
    const lastName = inputs.getElementsByTagName('input')[1].value;
    const facultyNumber = inputs.getElementsByTagName('input')[2].value;
    const grade = inputs.getElementsByTagName('input')[3].value;

    fetch(URL,{method: 'POST',
    body: JSON.stringify({
       firstName: `${firstName}`,
       lastName: `${lastName}`, 
       facultyNumber: `${facultyNumber}`, 
       grade: `${grade}`})},
       )
  })
}

attachEvents();