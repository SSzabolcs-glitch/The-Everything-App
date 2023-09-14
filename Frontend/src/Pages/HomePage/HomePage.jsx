import "./HomePage.css";
import { Link } from "react-router-dom";

function HomePage() {
  return (
    <div>
      <div className="white-bar"></div>
      <div className="main-message">
        <div className="main-message-content">

        <div className="main-message-elements">
          <div className="main-message-text">
            <div className="main-text-1">Rent or buy anything what you need</div>
            <div className="main-text-2">Quality products for rent and buy, delivery in one day</div>
            <Link to="/products">
              <button className="button-get-started">Get Started</button>
            </Link>
          </div>
        </div>
        <div className="main-picture-container">
          <div className="main-picture"></div>
        </div>
        </div>

      </div>
      
      <div className="what-we-offer-content">
        <div className="what-we-offer-text">What we offer</div>
        <div className="what-we-offer-container">
          <div className="what-we-offer-picture-and-text-container-1">
            <div className="what-we-offer-picture-1"></div>
            <div className="what-we-offer-text-1">
              Every project is unique, which is why we offer flexible rental and purchase options.
              Whether you need a tool for a day or two weeks, our rental periods cater to your specific
              requirements. Alternatively, if you find a tool you can&apos;t live without, you can choose
              to buy it and have it as a permanent addition to your toolkit. Your needs, your choices -
              that&apos;s the The Everything way.
            </div>
          </div>
          <div className="what-we-offer-picture-and-text-container-2">
            <div className="what-we-offer-picture-2"></div>
            <div className="what-we-offer-text-2">
              Your safety is paramount to us. That&apos;s why we take pride in providing only the highest quality
              and meticulously maintained tools in our inventory. Every tool undergoes rigorous safety checks
              and maintenance procedures to guarantee your peace of mind while working on your projects.
              With The Everything, you can trust that your tools are as safe as they are effective, making
              your DIY experience not only productive but also worry-free.
            </div>
          </div>
          <div className="what-we-offer-picture-and-text-container-3">
            <div className="what-we-offer-picture-3"></div>
            <div className="what-we-offer-text-3">
              We understand that time is of the essence when you have a project in mind.
              That&apos;s why we offer lightning-fast one-day order delivery, ensuring that you can get started
              on your DIY endeavor without delay. Say goodbye to waiting around for your tools, and hello
              to efficiency and productivity. We&apos;re here to make your projects happen when you need them most.
            </div>
          </div>
        </div>
      </div>

      <div className="discover-categories-content">
        <div className="discover-categories-text">Discover our categories</div>
        <div className="discover-categories-container">

          <div className="discover-categories-picture-and-text-container-1">
            <div className="discover-categories-picture-1"></div>
            <div className="discover-categories-text-1">category-1</div>
          </div>
          <div className="discover-categories-picture-and-text-container-2">
            <div className="discover-categories-picture-2"></div>
            <div className="discover-categories-text-2">category-2</div>
          </div>
          <div className="discover-categories-picture-and-text-container-3">
            <div className="discover-categories-picture-3"></div>
            <div className="discover-categories-text-3">category-3</div>
          </div>
          <div className="discover-categories-picture-and-text-container-4">
            <div className="discover-categories-picture-4"></div>
            <div className="discover-categories-text-4">category-4</div>
          </div>
          <div className="discover-categories-picture-and-text-container-5">
            <div className="discover-categories-picture-5"></div>
            <div className="discover-categories-text-5">category-5</div>
          </div>
        </div>
        <div className="discover-categories-container">
        <div className="discover-categories-picture-and-text-container-6">
            <div className="discover-categories-picture-6"></div>
            <div className="discover-categories-text-6">category-6</div>
          </div>
          <div className="discover-categories-picture-and-text-container-7">
            <div className="discover-categories-picture-7"></div>
            <div className="discover-categories-text-7">category-7</div>
          </div>
          <div className="discover-categories-picture-and-text-container-8">
            <div className="discover-categories-picture-8"></div>
            <div className="discover-categories-text-8">category-8</div>
          </div>
          <div className="discover-categories-picture-and-text-container-9">
            <div className="discover-categories-picture-9"></div>
            <div className="discover-categories-text-9">category-9</div>
          </div>
          <div className="discover-categories-picture-and-text-container-10">
            <div className="discover-categories-picture-10"></div>
            <div className="discover-categories-text-10">category-10</div>
          </div>
        </div>
      </div>

      <div className="white-bar"></div>
      <div className="one-day-delivery-content">
        <div className="one-day-delivery-text">Delivery in one day</div>
        <div className="one-day-delivery-container">

          <div className="one-day-delivery-picture-container-1">
            <div className="one-day-delivery-picture-1"></div>
          </div>

          <div className="one-day-delivery-picture-container-2">
            <div className="one-day-delivery-picture-2"></div>
          </div>

          <div className="one-day-delivery-text-container-3">
            <div className="one-day-delivery-text-3">
              In today&apos;s fast-paced world, time is a precious commodity, and we understand that when you&apos;re
              embarking on a DIY project or home renovation, waiting for tools to arrive can be a frustrating
              experience. That&apos;s precisely why we&apos;ve implemented our lightning-fast one-day order delivery
              service, designed with your convenience in mind.
              When you choose The Everything for your tool needs, you gain a significant advantage in terms
              of project planning and execution. Imagine waking up with the inspiration and motivation to
              tackle a home improvement project or DIY task, and by the end of the day, you have all the
              necessary tools at your doorstep. This rapid turnaround time eliminates the waiting game,
              allowing you to dive into your project without unnecessary delays.
            </div>
          </div>
        </div>
      </div>

      <div className="footer-menu-content">
        <div className="footer-menu-container">

          <div className="footer-menu-text-container-1">
            <div className="footer-menu-text-1-1"><b>Products</b></div>
            <div className="footer-menu-text-1-2">Rent</div>
            <div className="footer-menu-text-1-3">Buy</div>
            <div className="footer-menu-text-1-4">Catalog</div>
          </div>
          <div className="footer-menu-text-container-2">
            <div className="footer-menu-text-2-1"><b>Support</b></div>
            <div className="footer-menu-text-2-2">Contact Us</div>
            <div className="footer-menu-text-2-3">Find a location</div>
          </div>
          <div className="footer-menu-text-container-3">
            <div className="footer-menu-text-3-1"><b>About Us</b></div>
            <div className="footer-menu-text-3-2">History</div>
            <div className="footer-menu-text-3-3">Organization</div>
            <div className="footer-menu-text-3-4">Contact</div>
          </div>
          <div className="footer-menu-text-container-4">
            <div className="footer-menu-text-4-1"><b>Sustainability</b></div>
            <div className="footer-menu-text-4-2">Code of Conduct</div>
            <div className="footer-menu-text-4-3">International Guides</div>
          </div>
          <div className="footer-menu-text-container-5">
            <div className="footer-menu-text-5-1"><b>Career</b></div>
            <div className="footer-menu-text-5-2">Jobs</div>
            <div className="footer-menu-text-5-3">Your Development</div>
            <div className="footer-menu-text-5-4">Meet our People</div>
          </div>
        </div>
      </div>

      <div className="dark-blue-bar">© The Everything. All rights reserved.</div>

    </div>
    );
}



export default HomePage;