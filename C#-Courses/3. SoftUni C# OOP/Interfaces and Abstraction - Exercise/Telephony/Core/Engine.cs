
namespace Telephony.Core
{


    using Interfaces;
    using System;
    using Telephony.Exceptions;
    using Telephony.IO.Interfaces;
    using Telephony.Models;
    using Telephony.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartPhone smartPhone;


        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartPhone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }


        public void Run()
        {

            string[] phoneNumbers = this.reader.ReadLine().Split();
            string[] urls = this.reader.ReadLine().Split();


            foreach (var phoneNUmber in phoneNumbers)
            {
                try
                {

                    if (phoneNUmber.Length == 10)
                    {
                        this.writer.WriteLine(this.smartPhone.Call(phoneNUmber));
                    }
                    else if (phoneNUmber.Length == 7)
                    {
                        this.writer.WriteLine(this.stationaryPhone.Call(phoneNUmber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberExceptions();
                    }
                }
                catch (InvalidPhoneNumberExceptions ipne)
                {

                    this.writer.WriteLine(ipne.Message);
                }
                catch (Exception )
                {
                    throw;
                }
            }

            foreach (var url in urls)
            {
                try
                {

                    this.writer.WriteLine(this.smartPhone.BrowseURL(url));
                }
                catch (InvalidURLException iue)
                {

                    this.writer.WriteLine(iue.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
