const express = require('express'),
      home = require('./routes/home.js'),
      customer = require('./routes/customer');

const app = express();


//can use this to set the middleware
//app.configure(() => {
    app.set('title', 'CRM Application');    //get this config anywhere in the applications

    app.set('view engine', 'jade');
    app.set('views', __dirname + '/views');
    //app.use(express.logger('dev'));
    //app.use(express.favicon()); //many browsers requests this
    app.use(express.static(__dirname + '/public'));
//});

app.get('/', home.index);
app.get('/customers', customer.index);
app.get('/customers/:id', customer.customerId);
app.get('/customers/contacts', customer.contact);

app.listen(3000);
