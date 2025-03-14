using Factory_Method.SubscrioptionCreators;
using Factory_Method.Subscriptions;

SubscriptionCreator webSite = new WebSite();
Subscription domesticSubscription = webSite.OrderSubscription("domestic");
domesticSubscription.DisplayInfo();

SubscriptionCreator mobileApp = new MobileApp();
Subscription educationalSubscription = mobileApp.OrderSubscription("educational");
educationalSubscription.DisplayInfo();

SubscriptionCreator managerCall = new ManagerCall();
Subscription premiumSubscription = managerCall.OrderSubscription("premium");
premiumSubscription.DisplayInfo();