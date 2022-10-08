# 2Checkout .NET SDK

Current 2Checkout platform .NET SDK supporting .NET Standard 2.1+ and .NET Framework 4.6.2+.

This SDK Provides bindings to the 2Checkout 6.0 API, IPN, and ConvertPlus platform.


Installation
------------

Add TwoCheckout.dll to your project's references and add it's dependencies listed below.
* Newtonsoft.Json
* JWT


Example API Usage:
------------------

*Example Usage:*

```csharp
Dictionary<string, dynamic> PaymentMethodDictionary = new Dictionary<string, dynamic>();
Dictionary<string, dynamic> PaymentDetailsDictionary = new Dictionary<string, dynamic>();
Dictionary<string, dynamic> PriceDictionary = new Dictionary<string, dynamic>();
Dictionary<string, dynamic> ItemDictionary = new Dictionary<string, dynamic>();
Dictionary<string, string> BillingDetailsDictionary = new Dictionary<string, string>();
Dictionary<string, dynamic> OrderDetailsDictionary = new Dictionary<string, dynamic>();
dynamic[] items = { ItemDictionary };

# Billing Details
BillingDetailsDictionary.Add("Address1", "Test Address");
BillingDetailsDictionary.Add("City", "LA");
BillingDetailsDictionary.Add("State", "California");
BillingDetailsDictionary.Add("CountryCode", "US");
BillingDetailsDictionary.Add("Email", "testcustomer@2Checkout.com");
BillingDetailsDictionary.Add("FirstName", "Customer");
BillingDetailsDictionary.Add("LastName", "2Checkout");
BillingDetailsDictionary.Add("Zip", "12345");

# Item Details
PriceDictionary.Add("Amount", 1);
PriceDictionary.Add("Type", "CUSTOM");
ItemDictionary.Add("Name", "Dynamic product");
ItemDictionary.Add("Description", "Test description");
ItemDictionary.Add("Quantity", 1);
ItemDictionary.Add("IsDynamic", true);
ItemDictionary.Add("Tangible", false);
ItemDictionary.Add("PurchaseType", "PRODUCT");
ItemDictionary.Add("Price", PriceDictionary);

# Payment Method Details
PaymentMethodDictionary.Add("CardNumber", "4111111111111111");
PaymentMethodDictionary.Add("CardType", "VISA");
PaymentMethodDictionary.Add("Vendor3DSReturnURL", "www.success.com");
PaymentMethodDictionary.Add("Vendor3DSCancelURL", "www.fail.com");
PaymentMethodDictionary.Add("ExpirationYear", "2023");
PaymentMethodDictionary.Add("ExpirationMonth", "12");
PaymentMethodDictionary.Add("CCID", "123");
PaymentMethodDictionary.Add("HolderName", "John Doe");
PaymentMethodDictionary.Add("RecurringEnabled", false);
PaymentMethodDictionary.Add("HolderNameTime", 1);
PaymentMethodDictionary.Add("CardNumberTime", 1);
PaymentDetailsDictionary.Add("Type", "TEST");
PaymentDetailsDictionary.Add("Currency", "USD");
PaymentDetailsDictionary.Add("CustomerIP", "127.0.0.1");
PaymentDetailsDictionary.Add("PaymentMethod", PaymentMethodDictionary);

# Order Details
OrderDetailsDictionary.Add("Country", "us");
OrderDetailsDictionary.Add("Currency", "USD");
OrderDetailsDictionary.Add("CustomerIP", "127.0.0.1"");
OrderDetailsDictionary.Add("ExternalReference", "CustOrd100");
OrderDetailsDictionary.Add("Language", "en");
OrderDetailsDictionary.Add("Source", "tcolib.local");
OrderDetailsDictionary.Add("BillingDetails", BillingDetailsDictionary);
OrderDetailsDictionary.Add("Items", items);
OrderDetailsDictionary.Add("PaymentDetails", PaymentDetailsDictionary);

TwoCheckoutConfig twoCheckoutConfig = new TwoCheckoutConfig("{YOUR_MERCHANT_CODE}", "{YOUR_SECRET_KEY}");
TwoCheckoutOrder twoCheckoutOrder = new TwoCheckoutOrder();
string response = twoCheckoutOrder.PlaceOrder(twoCheckoutConfig, OrderDetailsDictionary);
```

*Example Response:*

```json
{
	"RefNo": "193612999",
	"OrderNo": 0,
	"ExternalReference": "CustOrd100",
	"ShopperRefNo": null,
	"Status": "AUTHRECEIVED",
	"ApproveStatus": "WAITING",
	"VendorApproveStatus": "OK",
	"MerchantCode": "{YOUR_MERCHANT_CODE}",
	"Language": "en",
	"OrderDate": "2022-10-08 17:00:09",
	"FinishDate": null,
	"Source": "tcolib.local",
	"WSOrder": null,
	"Affiliate": {
		"AffiliateCode": null,
		"AffiliateSource": null,
		"AffiliateName": null,
		"AffiliateUrl": null
	},
	"HasShipping": false,
	"BillingDetails": {
		"FiscalCode": null,
		"TaxOffice": null,
		"Phone": null,
		"FirstName": "Customer",
		"LastName": "2Checkout",
		"Company": null,
		"Email": "testcustomer@2Checkout.com",
		"Address1": "Test Address",
		"Address2": null,
		"City": "LA",
		"Zip": "12345",
		"CountryCode": "us",
		"State": "California"
	},
	"DeliveryDetails": {
		"Phone": null,
		"FirstName": "Customer",
		"LastName": "2Checkout",
		"Company": null,
		"Email": "testcustomer@2Checkout.com",
		"Address1": "Test Address",
		"Address2": null,
		"City": "LA",
		"Zip": "12345",
		"CountryCode": "us",
		"State": "California"
	},
	"PaymentDetails": {
		"Type": "TEST",
		"Currency": "usd",
		"PaymentMethod": {
			"FirstDigits": "4111",
			"LastDigits": "1111",
			"CardType": "visa",
			"ExpirationMonth": "12",
			"ExpirationYear": "23",
			"RecurringEnabled": false,
			"Vendor3DSReturnURL": null,
			"Vendor3DSCancelURL": null,
			"InstallmentsNumber": null
		},
		"CustomerIP": "127.0.0.1"
	},
	"DeliveryInformation": {
		"ShippingMethod": {
			"Code": null,
			"TrackingUrl": null,
			"TrackingNumber": null,
			"Comment": null
		}
	},
	"CustomerDetails": null,
	"Origin": "API",
	"AvangateCommission": 0.6,
	"OrderFlow": "REGULAR",
	"GiftDetails": null,
	"PODetails": null,
	"ExtraInformation": null,
	"PartnerCode": null,
	"PartnerMargin": null,
	"PartnerMarginPercent": null,
	"ExtraMargin": null,
	"ExtraMarginPercent": null,
	"ExtraDiscount": null,
	"ExtraDiscountPercent": null,
	"LocalTime": null,
	"TestOrder": true,
	"FxRate": 1,
	"FxMarkup": 0,
	"PayoutCurrency": "USD",
	"DeliveryFinalized": false,
	"Errors": null,
	"Items": [{
		"ProductDetails": {
			"Name": "Dynamic product",
			"ShortDescription": "Test description",
			"Tangible": false,
			"IsDynamic": true,
			"ExtraInfo": null,
			"RenewalStatus": false,
			"Subscriptions": null,
			"DeliveryInformation": {
				"Delivery": "NO_DELIVERY",
				"DownloadFile": null,
				"DeliveryDescription": "",
				"CodesDescription": "",
				"Codes": []
			}
		},
		"PriceOptions": [],
		"Price": {
			"UnitNetPrice": 1,
			"UnitGrossPrice": 1,
			"UnitVAT": 0,
			"UnitDiscount": 0,
			"UnitNetDiscountedPrice": 1,
			"UnitGrossDiscountedPrice": 1,
			"UnitAffiliateCommission": 0,
			"ItemUnitNetPrice": 0,
			"ItemUnitGrossPrice": 0,
			"ItemNetPrice": 0,
			"ItemGrossPrice": 0,
			"VATPercent": 0,
			"HandlingFeeNetPrice": 0,
			"HandlingFeeGrossPrice": 0,
			"Currency": "usd",
			"NetPrice": 1,
			"GrossPrice": 1,
			"NetDiscountedPrice": 1,
			"GrossDiscountedPrice": 1,
			"Discount": 0,
			"VAT": 0,
			"AffiliateCommission": 0
		},
		"LineItemReference": "b2783a4ae6d7af01d84b0ee9effa7937860bd311",
		"PurchaseType": "PRODUCT",
		"ExternalReference": "",
		"Quantity": 1,
		"SKU": null,
		"CrossSell": null,
		"Trial": null,
		"AdditionalFields": null,
		"Promotion": null,
		"RecurringOptions": null,
		"SubscriptionStartDate": null,
		"SubscriptionCustomSettings": null,
		"UpSell": null
	}],
	"Promotions": [],
	"AdditionalFields": null,
	"Currency": "usd",
	"NetPrice": 1,
	"GrossPrice": 1,
	"NetDiscountedPrice": 1,
	"GrossDiscountedPrice": 1,
	"Discount": 0,
	"VAT": 0,
	"AffiliateCommission": 0,
	"CustomParameters": null,
	"Refunds": null
}
```


Example IPN Usage:
------------------

*IPN Validation*

```csharp
# pass all parameters from IPN message as Dictionary<string, dynamic>
bool IsIpnResponseValid = TwoCheckoutIpn.IsIpnResponseValid("{YOUR_SECRET_KEY}", IpnParams);
```


*Generate IPN Response*

```csharp
# populate from IPN message
string[] IPNPID = { "35807759" };
string[] IPNPNAME = { "Cart_000001070" };
string[] IPN_DATE = { "20210517104249" };
Dictionary<string, dynamic> IpnResponse = new Dictionary<string, dynamic>();
IpnResponse.Add("IPNPID", IPNPID);
IpnResponse.Add("IPNPNAME", IPNPNAME);
IpnResponse.Add("IPN_DATE", IPN_DATE);

string IpnResponse = TwoCheckoutIpn.CalculateIpnResponse(SecretKey, Now, IpnParams);
# <EPAYMENT>20210518112122|14942802c5c411489e408f512f69c5fe</EPAYMENT>
```


Example ConvertPlus Signature Generation
------------------

```csharp
Dictionary<string, dynamic> CplusParamsDictionary = new Dictionary<string, dynamic>();
CplusParamsDictionary.Add("name", "John Doe");
CplusParamsDictionary.Add("phone", "756852919");
CplusParamsDictionary.Add("country", "US");
CplusParamsDictionary.Add("state", "Utah");
CplusParamsDictionary.Add("email", "example@example.com");
CplusParamsDictionary.Add("address", "Example");
CplusParamsDictionary.Add("city", "Utah");
CplusParamsDictionary.Add("company-name", "2co");
CplusParamsDictionary.Add("ship-name", "John Doe");
CplusParamsDictionary.Add("ship-country", "US");
CplusParamsDictionary.Add("ship-state", "Utah");
CplusParamsDictionary.Add("ship-city", "Utah");
CplusParamsDictionary.Add("ship-email", "example@example.com");
CplusParamsDictionary.Add("ship-address", "Example");
CplusParamsDictionary.Add("ship-address2", "dewdedw");
CplusParamsDictionary.Add("zip", "84101");
CplusParamsDictionary.Add("prod", "Cart_2");
CplusParamsDictionary.Add("price", 106);
CplusParamsDictionary.Add("qty", 1);
CplusParamsDictionary.Add("type", "PRODUCT");
CplusParamsDictionary.Add("tangible", "0");
CplusParamsDictionary.Add("src", "OPENCART_3_0_3_7");
CplusParamsDictionary.Add("return-url", "https://www.google.ro");
CplusParamsDictionary.Add("return-type", "redirect");
CplusParamsDictionary.Add("expiration", 1620911744);
CplusParamsDictionary.Add("order-ext-ref", "2");
CplusParamsDictionary.Add("item-ext-ref", "20210513081544");
CplusParamsDictionary.Add("customer-ext-ref", "example@example.com");
CplusParamsDictionary.Add("currency", "usd");
CplusParamsDictionary.Add("language", "en");
CplusParamsDictionary.Add("test", "1");
CplusParamsDictionary.Add("merchant", "{YOUR_MERCHANT_CODE}");
CplusParamsDictionary.Add("dynamic", 1);

TwoCheckoutConfig twoCheckoutConfig = new TwoCheckoutConfig("{YOUR_MERCHANT_CODE}", "{YOUR_SECRET_KEY}");
string Signature = TwoCheckoutCplusSignature.GetSignature(TwoCheckoutConfig, CplusParamsDictionary);
```


Exceptions:
------------------

TwoCheckoutException exceptions are thrown by if an error has returned. It is best to catch these exceptions so that they can be gracefully handled in your application.

*Example Catch*

```csharp
try
{
    string response = twoCheckoutOrder.PlaceOrder(twoCheckoutConfig, OrderDetailsDictionary);
    Console.Write(result);
}
catch (TwoCheckoutException e)
{
    Console.Write(e);
}
```

*Example Exception*

```json
{"error_code":"AUTHENTICATION_ERROR","message":"Internal error"}
```
