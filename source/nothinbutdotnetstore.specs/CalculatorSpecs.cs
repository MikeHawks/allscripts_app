using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Data.Common.DbConnection;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(Calculator))]
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<ICalculate,Calculator>
        {
        }

        public class when_adding_two_positive_numbers : concern
        {

            Establish c = () =>
            {
                connection = depends.on<System.Data.IDbConnecttion>();
            };
            Because b = () =>
                result = sut.add(2, 3);

            It should_return_the_sum = () =>
                result.ShouldEqual(5);

            static Connection connection;
            static int result;
        }

        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                spec.catch_exception(() => sut.add(2, 3));

            It should_throw_an_argument_exception = () =>
                spec.exception_thrown.ShouldBeAn<ArgumentException>();

        }
    }
}