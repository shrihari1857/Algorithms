exports.index = (req, res) => {
    res.send('Welcome to customer page');
};

exports.contact = (req, res) => {
    res.send('Welcome to customer contact page');
};

exports.customerId = (req, res) => {
    res.send('Selected Customer ' + req.params.id);
};

