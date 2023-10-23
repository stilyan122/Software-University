function softuni(input) {
    class Course {
        constructor(name,capacity){
            this.name = name;
            this.capacity= capacity;
            this.students=[];
        }
        addStudent(student){
            if(this.students.length+1<=this.capacity){
                this.students.push(student);
            }
        }
    }
    class Student{
        constructor(username,email,credits){
            this.username = username;
            this.email = email;
            this.credits = credits;
        }
    }
    input.reduce((acc,curr)=>{
        if(curr.includes(':')){
            const courseName = curr.split(': ')[0];
            const capacity = Number(curr.split(': ')[1]);
            const course = new Course(courseName,capacity);
            if(acc.find((course)=>course.name===courseName)===undefined)
            acc.push(course);
            else
            acc.find((course)=>course.name===courseName).capacity+=capacity;
        }
        else{
            const studentInfo = curr.split(' ')[0];
            const username = studentInfo.split('[')[0];
            const credits = Number(studentInfo.split('[')[1].slice(0,studentInfo.split('[')[1].length-1));
            const email = curr.split(' ')[3];
            const courseName = curr.split(' ').slice(5,curr.split(' ').length).join('');
            if(acc.find((course)=>course.name===courseName)!==undefined){
                acc.find((course)=>course.name===courseName).addStudent(new Student(username,email,credits));
            }
        }
        return acc;
    },[]).sort((a,b) => b.students.length - a.students.length).forEach((course)=>{
        console.log(`${course.name}: ${course.capacity-course.students.length} places left`);
        course.students.sort((a,b)=>b.credits - a.credits).forEach((student)=>{
            console.log(`--- ${student.credits}: ${student.username}, ${student.email}`);
        })
    })
}