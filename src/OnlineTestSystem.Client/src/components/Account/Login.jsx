import { useFormik } from "formik";
import { Form, Button } from "react-bootstrap";
import { CardWrapper } from "../general/CardWrapper";
import * as Yup from 'yup';


export const Login = ({ login, error }) => {
  const handleSubmit = values => {
    login(values.username, values.password);
  };

  const formik = useFormik({
    initialValues: {
      username: '',
      password: ''
    },
    validationSchema: Yup.object({
      username: Yup.string()
        .min(6, 'Must be 6 or more characters')
        .required('Required'),
      password: Yup.string()
        .min(6, 'Must be 6 or more characters')
        .required('Required'),
    }),
    onSubmit: handleSubmit,
  });

  return (
    <CardWrapper title="Login" className="shadow" style={{ width: "500px" }}>
      <Form onSubmit={formik.handleSubmit}>
        {error && <div className="bg-danger rounded p-2 text-white mb-2">{error}</div>}
        <Form.Group className="mb-3">
          <Form.Label htmlFor="username">Username:</Form.Label>
          <Form.Control
            id="username"
            name="username"
            type="text"
            placeholder="Enter your login"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.username} />
          {formik.touched.username && formik.errors.username ? <Form.Text className="text-danger">{formik.errors.username}</Form.Text> : null}
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label htmlFor="username">Password:</Form.Label>
          <Form.Control
            id="password"
            name="password"
            type="password"
            placeholder="Enter your password"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.password} />
          {formik.touched.password && formik.errors.password ? <Form.Text className="text-danger">{formik.errors.password}</Form.Text> : null}
        </Form.Group>
        <Button variant="primary" type="submit">Sign In</Button>
      </Form>
      <div>First user: TestUser1</div>
      <div>Second user: TestUser2</div>
      <div>Password: Secret123@</div>
    </CardWrapper>
  );
}

