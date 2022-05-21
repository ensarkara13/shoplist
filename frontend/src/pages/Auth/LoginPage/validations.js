import * as yup from "yup";

export const validationSchema = yup.object().shape({
  email: yup
    .string()
    .email("Geçerli bir email giriniz.")
    .required("Email alanı boş bırakılamaz."),
  password: yup
    .string()
    .min(8, "Şifreniz en az 8 karakterden oluşmalıdır.")
    .matches(/[A-Z]+/, {
      message: "Şifreniz en az bir büyük harf bulundurmalıdır.",
    })
    .matches(/[a-z]+/, {
      message: "Şifreniz en az bir küçük harf bulundurmalıdır.",
    })
    .matches(/[0-9]+/, {
      message: "Şifreniz en az bir rakam bulundurmalıdır.",
    })
    .required("Şifre alanı boş bırakılamaz."),
});
