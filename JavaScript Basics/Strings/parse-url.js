function solve(params) {
    let url = params[0];

    let semicolonIndex = url.indexOf(`:`),
        protocol = url.substring(0, semicolonIndex),
        slashAfterServerIndex = url.indexOf(`/`, semicolonIndex + 3),
        server = url.substring(semicolonIndex + 3, slashAfterServerIndex),
        resource = url.substring(slashAfterServerIndex);

    console.log(`protocol: ${protocol}`);
    console.log(`server: ${server}`);
    console.log(`resource: ${resource}`);
}

solve(['http://telerikacademy.com/Courses/Courses/Details/239']);