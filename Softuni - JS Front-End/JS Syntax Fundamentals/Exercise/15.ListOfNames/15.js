function naming(names) {
    return[...names]
    .sort((a,b) => a.localeCompare(b))
    .map((name,index) => index+1+"."+name)
    .join('\n');
}