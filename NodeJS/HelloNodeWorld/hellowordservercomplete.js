const http = require('http');

http.createServer((request, response) => {
  const { headers, method, url } = request;
  let reqBody = [];

  request.on('error', (err) => {
        console.error("ERROR: " + err);
  }).on('data', (part) => {
        reqBody.push(part);
  }).on('end', () => {
        reqBody = Buffer.concat(reqBody).toString();
  });
}).listen(1235); 