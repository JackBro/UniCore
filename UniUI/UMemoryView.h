﻿/*! \file UMemoryView.h
    \brief 内存视图。
    用于显示内存数据。

    \author uni
    \date 2012-1-17
*/
#ifndef UNIUI_UMEMORY_VIEW_H
#define UNIUI_UMEMORY_VIEW_H

#include <QtWidgets>

extern "C"
{
#include "../lua/lua.h"
#include "../lua/lualib.h"
#include "../lua/lauxlib.h"
}

class QDialogButtonBox;
class QLabel;
class QLineEdit;
class QTextEdit;

namespace uni
{

class UMemoryModel;
class UMemoryTable;

//! 内存视图。
/*!
    UMemoryView可以在某个指定的Lua状态下工作，这时UMemoryView中自定义的内存
    脚本可以使用该Lua状态下的全局的内容。

    主要功能如下，
    - 查看内存。
    - 修改内存。
    - 查找内存内容功能。
*/
class UMemoryView : public QWidget
{
    Q_OBJECT

public:

    //! 构造函数。
    /*!
        \param parent 父窗口句柄。
    */
    explicit UMemoryView(QWidget *parent = 0);
    virtual ~UMemoryView();
    //! 执行LuaC函数。
    /*!
        \param func 要执行的函数。
        该函数用于注册函数或是变量到UMemoryView使用的Lua环境。
    */
    void runLuaCFunction(lua_CFunction function);
public slots:
    //! 设置当前地址。
    void setAddress(int address);
    //! 设置要显示内存的进程ID.
    /*!
        \param pid 为-1时,代表自身所在进程.否则为其他进程.
        当目标进程不是自身进程时,会从共享内存中取得单元格数据.
    */
    void setTargetProcessID(int pid = -1);
    //! addressEdit内容改变。
    void addressEditChanged(const QString &text);
    //! 读取配置。
    /*!
        从当前进程所在目录的UMemoryView.cfg读取配置。
    */
    void readSettings();
    //! 保存配置。
    void writeSettings();

protected:
    //! 关闭事件。
    /*!
        关闭的时候保存列信息到当前进程所在目录。
    */
    void closeEvent(QCloseEvent *event);
private:

    QLabel *addressLabel_;
    QLineEdit *addressEdit_;
    UMemoryTable *memoryTable_;  //!< 显示内存内容的表格。
    UMemoryModel *memoryModel_;  //!< 显示内存内容的表格用到的数据模型。
    lua_State *L_;  //!< UMemoryView使用的Lua环境。
};

}//namespace uni

#endif//UNIUI_UMEMORY_VIEW_H