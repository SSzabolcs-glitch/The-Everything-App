import "./HomePage.css";

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
            <button className="button-get-started">Get Started</button>
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
    </div>
    );
}



export default HomePage;