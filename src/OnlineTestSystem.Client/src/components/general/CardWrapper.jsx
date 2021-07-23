import { Card } from "react-bootstrap"

export const CardWrapper = ({ title, variant = "light", children, ...props }) => (
  <Card {...props}>
    <h3 className={`bg-${variant} text-center ${variant !== 'light' ? "text-white" : ""} p-2`}>{title}</h3>
    <Card.Body>
      {children}
    </Card.Body>
  </Card>
)