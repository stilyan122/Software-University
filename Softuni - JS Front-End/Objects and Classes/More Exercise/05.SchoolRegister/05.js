function school(input){
    class Class{
       constructor(grade,students){
        this.students = students,
        this.grade=grade
       }
    }
    class Student{
        constructor(name,score){
            this.name = name,
            this.score = score
        }
    }
    let classes=[];
    for (const student of input) {
        const info = student.split(', ');
        const name = info[0].split(': ')[1];
        const grade = info[1].split(': ')[1];
        const score = Number(info[2].split(': ')[1]);
        if(score>=3.00){
            const person = new Student(name,score);
            if(classes.find((gr)=>gr.grade===grade)!==undefined){
                classes.find((gr)=>gr.grade===grade).students.push(person);
            }
            else{
                const clas = new Class(grade,[person]);
                classes.push(clas);
            }
        }
    }
    classes.sort((a,b) => a.grade - b.grade).forEach((clas) =>
    {
      let students = "";
      let average = 0;
      console.log(`${(Number(clas.grade))+1} Grade`);
      for (let index = 0; index < clas.students.length; index++) {
        const element = clas.students[index];
        if(index<clas.students.length-1){
            students+=element.name+', ';
        }
        else{
            students+=element.name;
        }
        average+=Number(element.score);
      }
      console.log(`List of students: ${students}`);
      console.log(`Average annual score from last year: ${(average/clas.students.length).toFixed(2)}`);
      console.log();
    });
}
