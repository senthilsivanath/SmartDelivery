
YUI().use('test-console', 'vantrip-view', 'helper', function (Y) {



    var test_Validation = new Y.Test.Case({

        /*---------------------------------------------
           Setup and tear down
        ---------------------------------------------
        In case of passing some data to the testCase we can set the data using the setUp
        and the tearDown will release the the memory

        */

        setUp: function () {
            this.data = { name: "Nicholas", age: 28 };
        },

        tearDown: function () {
            delete this.data;
        },

        _should: {
            ignore: {
                testName: true //ignore this test
            }
        },

        name: 'Validation() Tests',
        'Should perform validation': function () {

            var result = Y.VanTripView.prototype.Validation('','Enter Van trip ID');
            Y.Assert.areEqual("Enter Van trip ID", result, " the validation message should be :Enter Van trip ID ")
        }

    });

    var test_spacialCharcterValidation = new Y.Test.Case({

        name: 'spacialCharcterValidation() Tests',
        'Should perform spacial Charcter Validation': function () {

            var result = Y.VanTripView.prototype.spacialCharcterValidation(35);
            Y.Assert.areEqual(false, result,"Should return false as the input is # ")
        }

    });

    var test_getQueryVariable = new Y.Test.Case({

        name: 'getQueryVariable() Tests',
        'Should perform query string filter': function () {

            var result = Y.Helper.getQueryVariable('http://localhost:63518/#/navigation?OrderNumber=44&Sequence=1', 'OrderNumber');
            Y.Assert.areEqual('44', result, "Should return 44 after filtering query string.")
        }

    });

    /*Renders the resulet in selected div*/
    new Y.Test.Console().render('#testLogger');
    /*add all test*/
    Y.Test.Runner.add(test_Validation);
    Y.Test.Runner.add(test_spacialCharcterValidation);
    Y.Test.Runner.add(test_getQueryVariable);

    /*Run the test*/
    Y.Test.Runner.run();
});

