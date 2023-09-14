import "./DeliveryPage.css";

function DeliveryPage() {
  return (
    <div>
    <div className="white-bar"></div>
    <div className="main-message">
      <div className="title-text">Delivery information</div>

      <div className="content-container">
          <div className="picture-container">
              <div className="picture-10"></div>
          </div>
          <div className="main-text-2">
              <div className="paragraph-1">
              <p>In today&apos;s fast-paced world, time is a precious commodity, and we understand
                that when you&apos;sre embarking on a DIY project or home renovation, waiting for tools
                to arrive can be a frustrating experience. That&apos;s precisely why we&apos;ve implemented our
                <b> lightning-fast one-day order delivery service</b>, designed with your convenience in mind.</p>

              <p>When you choose The Everything for your tool needs, you gain a significant advantage
                in terms of project planning and execution. Imagine waking up with the inspiration and
                motivation to tackle a home improvement project or DIY task, and by the end of the day,
                you have all the necessary tools at your doorstep. This rapid turnaround time eliminates
                the waiting game, allowing you to dive into your project without unnecessary delays.</p>

              <p>The advantages of one-day order delivery go beyond just saving time. It enhances your
                overall project efficiency. Whether you&apos;re fixing a leaky faucet, building a piece of
                furniture, or undertaking a large-scale renovation, having the right tools at your disposal
                when you need them enables you to work more smoothly and achieve your project goals faster.</p>

              </div>
          </div>

      </div>

      <div className="main-text-2">

        <div className="paragraph-2">
          <p>Moreover, our one-day delivery service adds an element of flexibility to your planning.
            It&apos;s perfect for those unexpected last-minute projects or repairs that simply can&apos;t wait.
            You can count on us to be your dependable partner, ready to deliver the tools you require
            within hours of placing your order.</p>

          <p>In summary, one-day order delivery at The Everything is not just about speed; it&apos;s
            about empowerment and efficiency. We empower you to take action on your DIY dreams,
            providing the tools you need right when you need them. So, whether you&apos;re a seasoned DIY
            enthusiast or a beginner, choose The Everything for the fastest, most convenient,
            and hassle-free tool delivery service, and experience the advantages firsthand as you
            turn your visions into reality.</p>

          <p className="delivery-comapnies-pricing-text">Delivery companies and pricing options</p>

          <p className="delivery-comapnies-pricing-option-text-1">
          <b>1. SpeedyShip Express:</b><br/><br/>

            Pricing Tiers:<br/>
            Standard: $10<br/>
            Premium: $15 (Includes package tracking)<br/>
            VIP: $20 (Includes package tracking and delivery confirmation)<br/>
            Delivery Guarantee: Delivery within 24 hours of order placement.<br/>
            Coverage: Nationwide coverage, including remote areas.<br/>
          </p>
          <p className="delivery-comapnies-pricing-option-text-2">
            <b>2. RapidCourier Pro:</b><br/><br/>

            Pricing Tiers:<br/>
            Basic: $8<br/>
            Plus: $12 (Includes package tracking)<br/>
            Deluxe: $16 (Includes package tracking and delivery confirmation)<br/>
            Delivery Guarantee: Delivery within 24 hours, with an optional time-slot selection for an additional $5.<br/>
            Coverage: Servicing major metropolitan areas.<br/>
          </p>
          <p className="delivery-comapnies-pricing-option-text-3">
            <b>3. SwiftDeliver SuperSpeed:</b><br/><br/>
            Pricing Tiers:<br/>
            Quick: $12<br/>
            Turbo: $18 (Includes package tracking)<br/>
            Sonic: $25 (Includes package tracking and delivery confirmation)<br/>
            Delivery Guarantee: Guaranteed delivery within 12 hours of order placement, even for the fastest Sonic option.<br/>
            Coverage: Limited to major cities and urban hubs.<br/>
          </p>

          <p className="thankyou-text"><b>Thank you for choosing our one-day delivery service!</b></p>
        </div>
      </div>
    </div>
  </div>
    );
}



export default DeliveryPage;