using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using CompanyManagement.Web.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private CMDBContext db = new CMDBContext();
        // GET: Sale Invoice *************************************************************

        public ActionResult SIndex(int? pageNO)
        {
            TempData.Remove("Outgoing");
            int _pageNo = pageNO ?? 1;
            var Sinvoice = db.Invoices.OfType<OutGoing>().OrderByDescending(o => o.CreateTime).ToPagedList<OutGoing>(_pageNo, 11);
            return View(Sinvoice);
        }

        public ActionResult SCreate()
        {
            OutGoingCreateModel outgoing = TempData["Outgoing"] as OutGoingCreateModel;

            if (outgoing == null)
            {
                outgoing = new OutGoingCreateModel
                {
                    Ayar = 0,
                    Customers = db.Customers.ToList(),
                };
            }

            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return View(outgoing);
        }

        [HttpPost]
        public ActionResult SCreate(OutGoingCreateModel model1)
        {
            OutGoingCreateModel model = (TempData["Outgoing"] as OutGoingCreateModel);
            OutGoing outGoing = new OutGoing
            {
                CustomerId = model.CustomerId,
                CustomerUserName = model.CustomerUserName,
                Description = model.Description,
                ProcessTime = model.ProcessTime,
                CreateTime = model.CreateTime,
                Title = model.Title,
                AraToplam = model.AraToplam,
                KDVToplam = model.KDVToplam,
                GenelToplam = model.GenelToplam,
            };
            Invoice invoice = db.Invoices.Add(outGoing);
            db.SaveChanges();

            foreach (var product in model.ServiceProducts)
            {
                ServiceProduct serviceProduct = new ServiceProduct
                {
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    UnitPrice = product.UnitPrice,
                    Tax = product.Tax,
                    Total = product.Total,
                    InvoiceId = invoice.Id,
                };
                db.ServiceProducts.Add(serviceProduct);
            }

            db.SaveChanges();
            TempData.Remove("Outgoing");
            return RedirectToAction("SIndex", "Invoice");
        }

        [HttpPost]
        public ActionResult SAdd(OutGoingCreateModel model)
        {
            OutGoingCreateModel outgoing = TempData["Outgoing"] as OutGoingCreateModel;

            outgoing.Title = model.Title;
            outgoing.ProcessTime = model.ProcessTime;
            outgoing.CreateTime = model.CreateTime;
            outgoing.Description = model.Description;
            if (outgoing.CustomerUserName==null)
            {
                int customerid = Convert.ToInt32(model.CustomerUserName);
                outgoing.CustomerUserName = db.Customers.Find(customerid).UserName;
                outgoing.CustomerId = customerid;
            }


            outgoing.AraToplam = outgoing.AraToplam + (model.ServiceProduct.Quantity * model.ServiceProduct.UnitPrice);
            outgoing.KDVToplam = outgoing.KDVToplam + (model.ServiceProduct.Total - (model.ServiceProduct.Quantity * model.ServiceProduct.UnitPrice));
            outgoing.GenelToplam = outgoing.AraToplam + outgoing.KDVToplam;

            outgoing.Ayar = 1;

            if (outgoing.ServiceProducts == null)
            {
                outgoing.ServiceProducts = new List<ServiceProduct>();
            }
            Guid guid = Guid.NewGuid();
            model.ServiceProduct.UniqueId = guid.ToString();
            outgoing.ServiceProducts.Add(model.ServiceProduct);
            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return RedirectToAction("SCreate", "Invoice", new { id = outgoing.CustomerId });
        }

        public ActionResult SDelete(string UniqueId)
        {
            OutGoingCreateModel outgoing = TempData["Outgoing"] as OutGoingCreateModel;
            OutGoingCreateModel deneme = new OutGoingCreateModel();
            deneme.ServiceProducts = new List<ServiceProduct>();

            foreach (var serviceproduct in outgoing.ServiceProducts)
            {
                if (serviceproduct.UniqueId != UniqueId)
                {
                    deneme.ServiceProducts.Add(serviceproduct);
                }
                else
                {
                    outgoing.AraToplam = outgoing.AraToplam - (serviceproduct.Quantity * serviceproduct.UnitPrice);
                    outgoing.KDVToplam = outgoing.KDVToplam - (serviceproduct.Total - (serviceproduct.Quantity * serviceproduct.UnitPrice));
                    outgoing.GenelToplam = outgoing.AraToplam + outgoing.KDVToplam;
                }
            }

            outgoing.ServiceProducts = deneme.ServiceProducts;

            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return RedirectToAction("SCreate", "Invoice");
        }

        public ActionResult SEdit()
        {
            return View();
        }

        public ActionResult CICreate(int id)
        {
            OutgoingViewModel outgoing = TempData["Outgoing"] as OutgoingViewModel;
            Customer customer;

            if (outgoing == null)
            {
                customer = db.Customers.Find(id);
                outgoing = new OutgoingViewModel
                {
                    CustomerId = customer.Id,
                    CustomerUserName = customer.UserName,
                    Ayar = 0,
                };
            }

            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return View(outgoing);
        }

        [HttpPost]
        public ActionResult CICreate()
        {
            OutgoingViewModel model = (TempData["Outgoing"] as OutgoingViewModel);
            OutGoing outGoing = new OutGoing
            {
                CustomerId = model.CustomerId,
                CustomerUserName = model.CustomerUserName,
                Description = model.Description,
                ProcessTime = model.ProcessTime,
                CreateTime = model.CreateTime,
                Title = model.Title,
                AraToplam = model.AraToplam,
                KDVToplam = model.KDVToplam,
                GenelToplam = model.GenelToplam,
            };
            Invoice invoice = db.Invoices.Add(outGoing);
            db.SaveChanges();

            foreach (var product in model.ServiceProducts)
            {
                ServiceProduct serviceProduct = new ServiceProduct
                {
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    UnitPrice = product.UnitPrice,
                    Tax = product.Tax,
                    Total = product.Total,
                    InvoiceId = invoice.Id,
                };
                db.ServiceProducts.Add(serviceProduct);
            }

            db.SaveChanges();
            TempData.Remove("Outgoing");
            return RedirectToAction("Detail", "Customer", new { id = model.CustomerId });
        }

        [HttpPost]
        public ActionResult CIAdd(OutgoingViewModel model)
        {
            OutgoingViewModel outgoing = TempData["Outgoing"] as OutgoingViewModel;

            outgoing.Title = model.Title;
            outgoing.ProcessTime = model.ProcessTime;
            outgoing.CreateTime = model.CreateTime;
            outgoing.Description = model.Description;

            outgoing.AraToplam = outgoing.AraToplam + (model.ServiceProduct.Quantity * model.ServiceProduct.UnitPrice);
            outgoing.KDVToplam = outgoing.KDVToplam + (model.ServiceProduct.Total - (model.ServiceProduct.Quantity * model.ServiceProduct.UnitPrice));
            outgoing.GenelToplam = outgoing.AraToplam + outgoing.KDVToplam;

            outgoing.Ayar = 1;

            if (outgoing.ServiceProducts == null)
            {
                outgoing.ServiceProducts = new List<ServiceProduct>();
            }
            Guid guid = Guid.NewGuid();
            model.ServiceProduct.UniqueId = guid.ToString();
            outgoing.ServiceProducts.Add(model.ServiceProduct);
            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return RedirectToAction("CICreate", "Invoice", new { id = outgoing.CustomerId });
        }

        public ActionResult CIDelete(string UniqueId)
        {
            OutgoingViewModel outgoing = TempData["Outgoing"] as OutgoingViewModel;
            OutgoingViewModel deneme = new OutgoingViewModel();
            deneme.ServiceProducts = new List<ServiceProduct>();

            foreach (var serviceproduct in outgoing.ServiceProducts)
            {
                if (serviceproduct.UniqueId != UniqueId)
                {
                    deneme.ServiceProducts.Add(serviceproduct);
                }
                else
                {
                    outgoing.AraToplam = outgoing.AraToplam - (serviceproduct.Quantity * serviceproduct.UnitPrice);
                    outgoing.KDVToplam = outgoing.KDVToplam - (serviceproduct.Total - (serviceproduct.Quantity * serviceproduct.UnitPrice));
                    outgoing.GenelToplam = outgoing.AraToplam + outgoing.KDVToplam;
                }
            }

            outgoing.ServiceProducts = deneme.ServiceProducts;

            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return RedirectToAction("CICreate", "Invoice", new { id = outgoing.CustomerId });
        }

        public ActionResult CIDetail(int id)
        {
            OutGoing outGoing = db.Invoices.OfType<OutGoing>().FirstOrDefault(f => f.Id == id);

            InvoiceDetailModel model = new InvoiceDetailModel()
            {
                Id = outGoing.Id,
                Title = outGoing.Title,
                CustomerUserName = outGoing.CustomerUserName,
                AraToplam = outGoing.AraToplam,
                CreateTime = outGoing.CreateTime,
                CustomerId = outGoing.CustomerId,
                Description = outGoing.Description,
                GenelToplam = outGoing.GenelToplam,
                KDVToplam = outGoing.KDVToplam,
                ProcessTime = outGoing.ProcessTime,
                CustomerEmail = db.Customers.FirstOrDefault(f=>outGoing.CustomerUserName == f.UserName).Email,
                ServiceProducts = db.ServiceProducts.Where(w => w.InvoiceId == id).ToList(),
            };
            return View(model);
        }

        // GET: Buy Invoice ************************************************************ 
        public ActionResult BIndex(int? pageNO)
        {
            TempData.Remove("Outgoing");
            int _pageNo = pageNO ?? 1;
            var Sinvoice = db.Invoices.OfType<Incoming>().OrderByDescending(o => o.CreateTime).ToPagedList<Incoming>(_pageNo, 11);
            return View(Sinvoice);
        }

        public ActionResult BCreate()
        {
            OutGoingCreateModel outgoing = TempData["Outgoing"] as OutGoingCreateModel;

            if (outgoing == null)
            {
                outgoing = new OutGoingCreateModel
                {
                    Ayar = 0,
                    Customers = db.Customers.ToList(),
                };
            }

            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return View(outgoing);
        }

        [HttpPost]
        public ActionResult BCreate(OutGoingCreateModel model1)
        {
            OutGoingCreateModel model = (TempData["Outgoing"] as OutGoingCreateModel);
            Incoming outGoing = new Incoming
            {
                CustomerId = model.CustomerId,
                CustomerUserName = model.CustomerUserName,
                Description = model.Description,
                ProcessTime = model.ProcessTime,
                CreateTime = model.CreateTime,
                Title = model.Title,
                AraToplam = model.AraToplam,
                KDVToplam = model.KDVToplam,
                GenelToplam = model.GenelToplam,
            };
            Invoice invoice = db.Invoices.Add(outGoing);
            db.SaveChanges();

            foreach (var product in model.ServiceProducts)
            {
                ServiceProduct serviceProduct = new ServiceProduct
                {
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    UnitPrice = product.UnitPrice,
                    Tax = product.Tax,
                    Total = product.Total,
                    InvoiceId = invoice.Id,
                };
                db.ServiceProducts.Add(serviceProduct);
            }

            db.SaveChanges();
            TempData.Remove("Outgoing");
            return RedirectToAction("BIndex", "Invoice");
        }
        [HttpPost]
        public ActionResult BAdd(OutGoingCreateModel model)
        {
            OutGoingCreateModel outgoing = TempData["Outgoing"] as OutGoingCreateModel;

            outgoing.Title = model.Title;
            outgoing.ProcessTime = model.ProcessTime;
            outgoing.CreateTime = model.CreateTime;
            outgoing.Description = model.Description;
            if (outgoing.CustomerUserName == null)
            {
                int customerid = Convert.ToInt32(model.CustomerUserName);
                outgoing.CustomerUserName = db.Customers.Find(customerid).UserName;
                outgoing.CustomerId = customerid;
            }

            outgoing.AraToplam = outgoing.AraToplam + (model.ServiceProduct.Quantity * model.ServiceProduct.UnitPrice);
            outgoing.KDVToplam = outgoing.KDVToplam + (model.ServiceProduct.Total - (model.ServiceProduct.Quantity * model.ServiceProduct.UnitPrice));
            outgoing.GenelToplam = outgoing.AraToplam + outgoing.KDVToplam;

            outgoing.Ayar = 1;

            if (outgoing.ServiceProducts == null)
            {
                outgoing.ServiceProducts = new List<ServiceProduct>();
            }
            Guid guid = Guid.NewGuid();
            model.ServiceProduct.UniqueId = guid.ToString();
            outgoing.ServiceProducts.Add(model.ServiceProduct);
            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return RedirectToAction("BCreate", "Invoice", new { id = outgoing.CustomerId });
        }


        public ActionResult BDelete(string UniqueId)
        {
            OutGoingCreateModel outgoing = TempData["Outgoing"] as OutGoingCreateModel;
            OutGoingCreateModel deneme = new OutGoingCreateModel();
            deneme.ServiceProducts = new List<ServiceProduct>();

            foreach (var serviceproduct in outgoing.ServiceProducts)
            {
                if (serviceproduct.UniqueId != UniqueId)
                {
                    deneme.ServiceProducts.Add(serviceproduct);
                }
                else
                {
                    outgoing.AraToplam = outgoing.AraToplam - (serviceproduct.Quantity * serviceproduct.UnitPrice);
                    outgoing.KDVToplam = outgoing.KDVToplam - (serviceproduct.Total - (serviceproduct.Quantity * serviceproduct.UnitPrice));
                    outgoing.GenelToplam = outgoing.AraToplam + outgoing.KDVToplam;
                }
            }

            outgoing.ServiceProducts = deneme.ServiceProducts;

            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return RedirectToAction("BCreate", "Invoice");
        }

        public ActionResult BEdit()
        {
            return View();
        }


        public ActionResult CBCreate(int id)
        {
            OutgoingViewModel outgoing = TempData["Outgoing"] as OutgoingViewModel;
            Customer customer;

            if (outgoing == null)
            {
                customer = db.Customers.Find(id);
                outgoing = new OutgoingViewModel
                {
                    CustomerId = customer.Id,
                    CustomerUserName = customer.UserName,
                    Ayar = 0,
                };
            }

            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return View(outgoing);
        }

        [HttpPost]
        public ActionResult CBCreate()
        {
            OutgoingViewModel model = (TempData["Outgoing"] as OutgoingViewModel);
            Incoming incoming = new Incoming
            {
                CustomerId = model.CustomerId,
                CustomerUserName = model.CustomerUserName,
                Description = model.Description,
                ProcessTime = model.ProcessTime,
                CreateTime = model.CreateTime,
                Title = model.Title,
                AraToplam = model.AraToplam,
                KDVToplam = model.KDVToplam,
                GenelToplam = model.GenelToplam,
            };

            Invoice invoice = db.Invoices.Add(incoming);
            db.SaveChanges();

            foreach (var product in model.ServiceProducts)
            {
                ServiceProduct serviceProduct = new ServiceProduct
                {
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    UnitPrice = product.UnitPrice,
                    Tax = product.Tax,
                    Total = product.Total,
                    InvoiceId = invoice.Id,
                };
                db.ServiceProducts.Add(serviceProduct);
            }

            db.SaveChanges();
            TempData.Remove("Outgoing");
            return RedirectToAction("Detail", "Customer", new { id = model.CustomerId });
        }

        [HttpPost]
        public ActionResult CBAdd(OutgoingViewModel model)
        {
            OutgoingViewModel outgoing = TempData["Outgoing"] as OutgoingViewModel;

            outgoing.Title = model.Title;
            outgoing.ProcessTime = model.ProcessTime;
            outgoing.CreateTime = model.CreateTime;
            outgoing.Description = model.Description;

            outgoing.AraToplam = outgoing.AraToplam + (model.ServiceProduct.Quantity * model.ServiceProduct.UnitPrice);
            outgoing.KDVToplam = outgoing.KDVToplam + (model.ServiceProduct.Total - (model.ServiceProduct.Quantity * model.ServiceProduct.UnitPrice));
            outgoing.GenelToplam = outgoing.AraToplam + outgoing.KDVToplam;

            outgoing.Ayar = 1;

            if (outgoing.ServiceProducts == null)
            {
                outgoing.ServiceProducts = new List<ServiceProduct>();
            }
            Guid guid = Guid.NewGuid();
            model.ServiceProduct.UniqueId = guid.ToString();
            outgoing.ServiceProducts.Add(model.ServiceProduct);
            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return RedirectToAction("CBCreate", "Invoice", new { id = outgoing.CustomerId });
        }

        public ActionResult CBDelete(string UniqueId)
        {
            OutgoingViewModel outgoing = TempData["Outgoing"] as OutgoingViewModel;
            OutgoingViewModel deneme = new OutgoingViewModel();
            deneme.ServiceProducts = new List<ServiceProduct>();

            foreach (var serviceproduct in outgoing.ServiceProducts)
            {
                if (serviceproduct.UniqueId != UniqueId)
                {
                    deneme.ServiceProducts.Add(serviceproduct);
                }
                else
                {
                    outgoing.AraToplam = outgoing.AraToplam - (serviceproduct.Quantity * serviceproduct.UnitPrice);
                    outgoing.KDVToplam = outgoing.KDVToplam - (serviceproduct.Total - (serviceproduct.Quantity * serviceproduct.UnitPrice));
                    outgoing.GenelToplam = outgoing.AraToplam + outgoing.KDVToplam;
                }
            }

            outgoing.ServiceProducts = deneme.ServiceProducts;

            TempData["Outgoing"] = outgoing;
            TempData.Keep("Outgoing");
            return RedirectToAction("CBCreate", "Invoice", new { id = outgoing.CustomerId });
        }

        public ActionResult CBDetail(int id)
        {
            Incoming outGoing = db.Invoices.OfType<Incoming>().FirstOrDefault(f => f.Id == id);

            InvoiceDetailModel model = new InvoiceDetailModel()
            {
                Title = outGoing.Title,
                CustomerUserName = outGoing.CustomerUserName,
                AraToplam = outGoing.AraToplam,
                CreateTime = outGoing.CreateTime,
                CustomerId = outGoing.CustomerId,
                Description = outGoing.Description,
                GenelToplam = outGoing.GenelToplam,
                KDVToplam = outGoing.KDVToplam,
                ProcessTime = outGoing.ProcessTime,
                ServiceProducts = db.ServiceProducts.Where(w => w.InvoiceId == id).ToList(),
            };

            return View(model);
        }

        public ActionResult CDelete(int id)
        {
            var invoice = db.Invoices.Find(id);

            if (invoice != null)
            {
                var result = db.Invoices.Remove(invoice);
                db.SaveChanges();

                return RedirectToAction("Detail", "Customer", new { id = invoice.CustomerId });
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }

        public ActionResult Delete(int id)
        {
            var invoice = db.Invoices.Find(id);

            if (invoice != null)
            {
                var result = db.Invoices.Remove(invoice);
                db.SaveChanges();

                return RedirectToAction("Detail", "Customer", new { id = invoice.CustomerId });
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }

        [HttpGet]
        public JsonResult GetSearchProductValue(string search)
        {
            List<ProductAutoCompletedModel> allsearch = db.ServiceProducts.Where(x => x.Name.StartsWith(search)).Select(w => new ProductAutoCompletedModel
            {
                Id = w.Id,
                Name = w.Name,
            }).ToList();

            var myList = new List<string>();
            foreach (var item in allsearch)
            {
                foreach (var item2 in myList)
                {
                    if (item2 == item.Name)
                    {
                        item.Name = null;
                    }
                }
                myList.Add(item.Name);
            }

            var y = allsearch.Where(w => w.Name != null).ToList();

            if (allsearch.Count() == 0)
            {
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = y, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Send(InvoiceDetailModel model)
        {
            OutGoing outGoing = db.Invoices.OfType<OutGoing>().FirstOrDefault(f => f.Id == model.Id);

            InvoiceDetailModel invoice = new InvoiceDetailModel()
            {
                Id = outGoing.Id,
                Title = outGoing.Title,
                CustomerUserName = outGoing.CustomerUserName,
                AraToplam = outGoing.AraToplam,
                CreateTime = outGoing.CreateTime,
                CustomerId = outGoing.CustomerId,
                Description = outGoing.Description,
                GenelToplam = outGoing.GenelToplam,
                KDVToplam = outGoing.KDVToplam,
                ProcessTime = outGoing.ProcessTime,
                CustomerEmail = model.CustomerEmail,
                ServiceProducts = db.ServiceProducts.Where(w => w.InvoiceId == model.Id).ToList(),
            };
            return View(invoice);
        }

        public ActionResult PaymentForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PaymentForm(Iyzipay.Model.Payment model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-JNylvWmC8rOoRffE0Btm23NM6SyWpv4j";
            options.SecretKey = "sandbox-78LDtQHo7tlBpUbsuqEm0SYDtOjSdYS3";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = "1";
            request.PaidPrice = "1.2";
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = "John Doe";
            paymentCard.CardNumber = "5528790000000008";
            paymentCard.ExpireMonth = "12";
            paymentCard.ExpireYear = "2030";
            paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            Iyzipay.Model.Payment payment = Iyzipay.Model.Payment.Create(request, options);
            return View(payment);
        }

    }
}