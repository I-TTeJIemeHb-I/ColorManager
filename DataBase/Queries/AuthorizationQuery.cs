using ColorManager.Data.Models;
using ColorManager.Data.Views.Authorization;
using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Navigation;

namespace ColorManager.DataBase.Queries
{
    public class AuthorizationQuery
    {
        // IP-адрес
        public static string host = Dns.GetHostName();
        public static IPAddress[] address = Dns.GetHostAddresses(host);
        // Одноразовый код подтверждения
        public static string securityCode;


        /// <summary>
        /// Выполняет отправку сообщения на почту
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <returns>Возвращает отправленный одноразовый код</returns>
        public static void SendCodeToEmail(string email)
        {
            // Генерируем одноразовый код и отправляем его на почту
            Random random = new Random();
            securityCode = random.Next(100000, 999999).ToString();

            // Код для отправки письма на почту
            // Пока заменим
            MessageBox.Show(securityCode);
        }


        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>true при успешной авторизации / false при неудаче. Меняет состояние отображение футера и статус авторизации пользователя</returns>
        public static bool SignIn(string login, string password)
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    var users = db.Users;

                    // Ищет пользователя с полученным Login и возвращает null или экземпляр класса Users
                    var user = users.FirstOrDefault(u => u.Login == login);

                    // Если пользователь по указанному логину найден
                    if (user != null)
                    {
                        // Проверяем пароль
                        if (user.Password == password)
                        {
                            // Передаём информацию в статический класс
                            MainModel.getInstance().Login = user.Login;
                            User.Login = user.Login;
                            User.Email = user.Email;
                            User.IsAuthorizate = true;
                            // Передаём в базу данных текущий IP-адрес
                            //user.IP = address[0].ToString();
                            //db.SaveChanges();
                            // Возвращаем результат авторизации
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль", "Color Manager: Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    // Если пользователь по указанному логину не найден
                    else
                    {
                        MessageBox.Show("Пользователя с указанным Логином не существует", "Color Manager: Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Color Manager: Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        /// <summary>
        /// Выполняет проверку на возможность регистрации пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>true при возможности зарегестрироваться / false при занятых логине или почте</returns>
        public static bool CanSignUp(string login, string email, string password)
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    var users = db.Users;

                    // Ищет пользователя у котрого Login и Email аналогичны
                    var user = users.FirstOrDefault(u => u.Login == login || u.Email == email);

                    // Если пользователи найдены
                    // Возможность регистрации - отсутствует
                    if (user != null)
                    {
                        MessageBox.Show("Указанные Логин и Почта заняты", "Color Manager: Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    // Если пользователи не найдены
                    // Возможность регистрации - присутствует
                    else
                    {
                        // Отправляем одноразовый код на почту
                        SendCodeToEmail(email);
                        // Подготавливаем данные для регистрации
                        User.Login = login;
                        User.Email = email;
                        User.Password = password;

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Color Manager: Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        /// <summary>
        /// Выполняет проверку на возможность восстановления пароля пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>true при возможности восстановить пароль / false при не совпадающем логине</returns>
        public static bool CanRecover(string login, string email, string password)
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    var users = db.Users;

                    var user = users.FirstOrDefault(u => u.Login == login && u.Email == email);

                    if (user != null)
                    {
                        // Отправляем одноразовый код на почту
                        SendCodeToEmail(email);
                        // Подготавливаем данные для регистрации
                        User.Login = login;
                        User.Email = email;
                        user.Password = password;

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Пользователя с указанным Логином не существует", "Color Manager: Восстановление пароля", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Color Manager: Восстановление пароля", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        /// <summary>
        /// Выполняет регистрацию пользователя в приложении
        /// </summary>
        /// <param name="code">Одноразовый код подтверждения</param>
        public static bool SignUp(string code)
        {
            if (securityCode == code)
            {
                try
                {
                    using (var db = new ApplicationContext())
                    {
                        //Создаем пользователя
                        Users user = new Users() { Login = User.Login, Email = User.Email, Password = User.Password, Name = User.Login };
                        //Отправляем его в БД
                        db.Add(user);
                        // Сохраняем изменения
                        db.SaveChanges();

                        MessageBox.Show("Регистрация пройдена успешно. Авторизуйтесь чтобы начать работу в приложении", "Color Manager: Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Color Manager: Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Неверный одноразовый код", "Color Manager: Регистрация", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        /// <summary>
        /// Выполняет Изменение почты пользователя
        /// </summary>
        /// <param name="code">Одноразовый код подтверждения</param>
        public static bool RecoverPassword(string code)
        {
            if (securityCode == code)
            {
                try
                {
                    using (var db = new ApplicationContext())
                    {
                        // Ищем пользователя
                        var user = db.Users.FirstOrDefault(u => u.Login == User.Login && u.Email == User.Email);
                        // Присваиваем новый пароль
                        user.Password = User.Password;
                        // Сохраняем изменения
                        db.SaveChanges();

                        MessageBox.Show("Пароль изменён успешно. Авторизуйтесь чтобы начать работу в приложении", "Color Manager: Восстановление пароля", MessageBoxButton.OK, MessageBoxImage.Information);

                        return true;
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Color Manager: Восстановление пароля", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Неверный одноразовый код", "Color Manager: Восстановление пароля", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

    }
}
