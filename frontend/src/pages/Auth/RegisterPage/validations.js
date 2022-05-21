import * as yup from "yup";

export const validationSchema = yup.object().shape({
  firstName: yup
    .string()
    .trim()
    .matches(/^[A-Za-z]+$/, {
      message: "İsminiz rakam veya özel karakter bulunduramaz.",
    })
    .required("İsim alanı boş bırakılamaz."),
  lastName: yup
    .string()
    .trim()
    .matches(/^[A-Za-z]+$/, {
      message: "Soyisminiz rakam veya özel karakter bulunduramaz.",
    })
    .required("Soyisim alanı boş bırakılamaz."),
  email: yup
    .string()
    .trim()
    .email("Geçerli bir email giriniz.")
    .required("Email alanı boş bırakılamaz."),
  password: yup
    .string()
    .trim()
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
  confirmPassword: yup
    .string()
    .trim()
    .oneOf([yup.ref("password")], "Şifreler uyuşmuyor.")
    .required("Şifre tekrar alanı boş bırakılamaz."),
});
