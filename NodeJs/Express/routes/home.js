exports.index = (req, res) => {
   // res.send('Welcome to Index home page');
   res.render('home/index', 
        {
            title: 'Home Page1',
            firstPara: 'Welcome'   
        });
};

