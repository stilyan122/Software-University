function loadCommits() {
    let username = document.getElementById("username");
    let repo = document.getElementById("repo");
    let ul = document.getElementById("commits");
    const URL = "https://api.github.com/repos/"+username.value+"/"+repo.value+"/commits";
    fetch(URL)
    .catch(err=>{
        let li = document.createElement("li");
        li.textContent="Error: "+ err.status()+" (Not Found)"; 
        ul.appendChild(li);
    })
    .then(res => res.json())
    .then(data=>{
        data.forEach(element => {
            let li = document.createElement("li");
            li.textContent=element.commit.author.name+": "+element.commit.message; 
            ul.appendChild(li);
        });
    })
    .catch(err=>{
        let li = document.createElement("li");
        li.textContent="Error: "+ err.status()+" (Not Found)"; 
        ul.appendChild(li);
    });
}