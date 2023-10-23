function loadRepos() {
	let username = document.getElementById("username").value;
	const URL = "https://api.github.com/users/"+username+"/repos";
	let ul = document.getElementById("repos");
	ul.removeChild(ul.children[0]);
	fetch(URL)
	.then(data=>data.json())
	.then(result =>
		result.forEach(
			(val)=>{
			let li = document.createElement("li");
			let a = document.createElement("a");
			a.textContent = val.full_name;
			a.href=val.html_url;
			li.appendChild(a);
			ul.appendChild(li);
			}
		)
		)
    .catch(err=>
	{
		let li =document.createElement("li");
		li.textContent = err.value;
	}
    )
}