# PubSub Demo – Simple Publish/Subscribe Architecture (C# / .NET)

این پروژه یک نمونه‌ی ساده از الگوی Pub/Sub در .NET است که نشان می‌دهد چطور یک Event منتشر می‌شود و چندین Subscriber مختلف به آن واکنش نشان می‌دهند.  
این ساختار برای پروژه‌های ماژولار، Event-Driven و معماری‌های میکروسرویسی بسیار کاربردی است.

---

## 📁 ساختار پروژه



### توضیح لایه‌ها

#### **Core**
تمام Interface‌ های عمومی و قراردادهای اصلی سیستم این‌جا قرار دارند.  
این لایه وابسته به هیچ پروژه دیگری نیست.

#### **Infrastructure**
پیاده‌سازی EventBus داخل این لایه است.  
EventBus مسئول ثبت Subscriberها و ارسال Event به آن‌هاست.

#### **Events**
تمام Eventهایی که در سیستم منتشر می‌شوند اینجا قرار می‌گیرند.  
هر Event از `IEvent` ارث‌بری می‌کند.

#### **Subscribers**
تمام Subscriberهای سیستم داخل این پوشه‌اند.  
هر Subscriber یک Event خاص را هندل می‌کند.

---

## نحوه اجرا

برنامه از طریق `Program.cs` اجرا می‌شود:

1. ساخت EventBus
2. ثبت Subscriber‌ها
3. انتشار یک Event
4. دریافت Event از سمت هر Subscriber
